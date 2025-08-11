using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace EndPoint.Users.MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CheckNull
    {
        private readonly RequestDelegate _next;

        public CheckNull(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            
           await  _next(httpContext);
        }
    } 

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CheckNullExtensions
    {
        public static IApplicationBuilder UseCheckNull(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CheckNull>();
        }
    }
}
