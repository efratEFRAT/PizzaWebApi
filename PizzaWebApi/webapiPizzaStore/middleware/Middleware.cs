using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using FireService.Interfaces;
using FireService;
namespace תשתית_לניהול_חנות_פיצה_חני_גולדברג.middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
       
        private readonly RequestDelegate _next;
        IFireService<string>  _fileServise;
        public Middleware(RequestDelegate next,IFireService<string>  fileServise)
        {
            _next = next;
            _fileServise=fileServise;       
        }

        public Task Invoke(HttpContext httpContext)
        {
            var request = httpContext.Request;
            _fileServise.Write("the request time:"+ DateTime.Now.ToString());
            _fileServise.Write("the httpmethod :"+ request.Method.ToString());
            _fileServise.Write("the body parameters:"+ request.Body.ToString());
            _fileServise.Write("the request header:"+request.Headers.ToString());
            var Task= _next(httpContext);
            return Task;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions 
    {
        public static IApplicationBuilder UseCustom (this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
