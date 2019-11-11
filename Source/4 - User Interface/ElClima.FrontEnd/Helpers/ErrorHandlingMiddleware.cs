using ElClima.Domain.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ElClima.FrontEnd.Helpers
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(context, ex);
            }

            
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            switch (exception)
            {
                //case MyNotFoundException _:
                //    code = HttpStatusCode.NotFound;
                //    break;
                //case MyUnauthorizedException _:
                //    code = HttpStatusCode.Unauthorized;
                //    break;
                //case MyException _:
                //    code = HttpStatusCode.BadRequest;
                //    break;

                case ElClimaException _:

                    var resultMsg = JsonConvert.SerializeObject(new { error = exception.Message });
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = (int)code;
                    return context.Response.WriteAsync(resultMsg);
            } 

            var msg = exception.Message;
            if (exception.InnerException != null)
            {
                msg = msg + " || " + exception.InnerException.Message;
            }

            var result = JsonConvert.SerializeObject(new { error = msg });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
