using BackEndAPI.Models;
using BackEndAPI.src.Base.Contracts.Service;
using BackEndAPI.src.Base.DB;
using BackEndAPI.src.Base.Ioc;
using BackEndAPI.src.Base.Middlewares;
using BackEndAPI.src.Base.Utilities;
using BackEndAPI.src.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Load Config Settings
AppSettings.LoadSettings(builder.Configuration);

//config dependencie injector
Ioc.ConfigureDependencieInjector(builder.Services);

builder.Services.AddDbContext<DataContext>(opt => opt.UseNpgsql(AppSettings.SqlStringConnection));


//builder.Services.AddTransient<JwtMiddleware>();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.Use((context, next) =>
{
    context.Request.EnableBuffering();
    return next();
});

app.MapControllers();
//app.UseMiddleware<JwtMiddleware>();

app.Run();
