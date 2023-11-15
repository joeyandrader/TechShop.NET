using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BackEndAPI.Models
{
    public class RawJsonActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            context.HttpContext.Request.Body.Seek(0, SeekOrigin.Begin);
            if (context.ActionArguments.ContainsKey("updateDTO"))
            {
                context.HttpContext.Request.EnableBuffering();

                using (StreamReader reader = new StreamReader(context.HttpContext.Request.Body))
                {
                    //string json = JsonConvert.SerializeObject(reader);
                    string json = reader.ReadToEnd();
                    context.HttpContext.Items["RawJson"] = json;
                    // Rebobina o corpo da requisição para que possa ser lido novamente na desserialização
                    context.HttpContext.Request.Body.Position = 0;
                }
            }

            await next();
        }
    }
}