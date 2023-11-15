using System.Reflection;
using System.Text;
using BackEndAPI.Models;
using BackEndAPI.src.Base.Contracts.Service;
using BackEndAPI.src.Base.DB;
using BackEndAPI.src.Base.Ioc;
using BackEndAPI.src.Base.Middlewares;
using BackEndAPI.src.Base.Utilities;
using BackEndAPI.src.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "TechShop API", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        In = ParameterLocation.Header,
        Description = "JWT auth",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement()
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] { }
    }
});

    // Habilita comentario no Swagger atraves do <summary></summary>
    //
    // USE a config abaixo em .csproj em <PropertyGroup></PropertyGroup>
    // ====================================================================
    //  <GenerateDocumentationFile>true</GenerateDocumentationFile>
    //	<NoWarn>$(NoWarn); 1591 </NoWarn>
    // ====================================================================
    // Dessa forma habilitado o comentario no swagger
    //
    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
    opt.IncludeXmlComments(xmlPath);
});


//Load Config Settings
AppSettings.LoadSettings(builder.Configuration);

//config dependencie injector
Ioc.ConfigureDependencieInjector(builder.Services);


//Auth Mode
//Authenticate Service
var key = Encoding.ASCII.GetBytes(AppSettings.JwtKey);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddDbContext<DataContext>(opt => opt.UseNpgsql(AppSettings.SqlStringConnection));


builder.Services.AddTransient<JwtMiddleware>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserContextService, UserContextService>();
builder.Services.AddScoped<RawJsonActionFilter>();

//Add Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("Default",
                          policy =>
                          {
                              policy.AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                          });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("Default");


app.UseWhen(context => context.Request.Method == "OPTIONS", (IApplicationBuilder app) =>
{
    app.Run(async context =>
    {
        context.Response.StatusCode = 200;
        context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
        context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
        context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");
        await context.Response.WriteAsync("Preflight request handled.");
    });
});

app.UseRouting();
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseAuthorization();

app.Use((context, next) =>
{
    context.Request.EnableBuffering();
    return next();
});

app.MapControllers();
app.UseMiddleware<JwtMiddleware>();

app.Run();
