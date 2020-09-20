using System;
using System.Net;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Shp.Core.Extensions
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            string message = "Internal Server Error";
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
            if (e is ValidationException)
            {
                message = e.Message;
                httpContext.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
            }

            return httpContext.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}
