using CompanyEmployees.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace CompanyEmployees.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next)
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
            var response = context.Response;
            response.ContentType = "application/json";
            HttpStatusCode status;

            switch (exception)
            {
                case NotFoundException e:
                    status = HttpStatusCode.NotFound;
                    break;
                default:
                    status = HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(new { error = exception?.Message });
            response.StatusCode = (int)status;
            return response.WriteAsync(result);
        }
    }
}
