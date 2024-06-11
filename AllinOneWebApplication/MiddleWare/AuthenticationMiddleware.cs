using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AllinOneWebApplication.MiddleWare
{

    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            // Check if the request is not for the login page
            if (!context.Request.Path.Equals("/Login/Login", StringComparison.OrdinalIgnoreCase))
            {

                // Check if the session variable "UserName" is null
                if (context.Session.GetString("UserInfo") == null)
                {
                    // Redirect unauthenticated users to the login page
                    context.Response.Redirect("/Login/Login");
                    return;
                }
            }
            // Call the next middleware in the pipeline
            await _next(context);
        }


    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}
