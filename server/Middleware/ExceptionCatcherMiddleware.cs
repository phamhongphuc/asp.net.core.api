using System;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using server.Middleware.Error;

namespace server.Middleware
{
    public class ExceptionCatcherMiddleware : IMiddleware
    {
        public IHostingEnvironment Env { get; }

        public ExceptionCatcherMiddleware(IHostingEnvironment env)
        {
            Env = env;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = MediaTypeNames.Application.Json;
            response.StatusCode = StatusCodes.Status500InternalServerError;

            var error = new ErrorResponse();

            if (exception is BaseError)
            {
                var baseError = (BaseError)exception;

                response.StatusCode = (int)baseError.StatusCode;
                error.Description = baseError.Description;
                error.Model = baseError.Model;
                await response.WriteAsync((string)error);
            }
            else if (Env.IsDevelopment()) throw exception;
        }
    }
}
