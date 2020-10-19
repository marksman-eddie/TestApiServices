using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TestAppZscb.Middlewares
{
    public class ExceptionMiddleware
    {        
        private RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                await (_next(context));
            }

            catch (Exception ex)
            {                
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/text;charset=utf-8";
                await context.Response.WriteAsync($"{ex.Message}");
            }

        }

    }
}
