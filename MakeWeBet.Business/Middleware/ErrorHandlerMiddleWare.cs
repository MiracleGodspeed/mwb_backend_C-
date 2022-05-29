using MakeWeBet.Business.Infrastructure.Exceptions;
using MakeWeBet.Data.Models.ExceptionModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MakeWeBet.Business.Middleware
{
    public class ErrorHandlerMiddleWare
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILogger<ErrorHandlerMiddleWare> logger)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                logger.LogError(error.ToString());
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case AppException:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case NotFoundException:
                    //    // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    //case ArgumentNullException:
                    //    // null error
                    //    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    //    break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new { message = error?.Message, statusCode = response.StatusCode });
                await response.WriteAsync(result);

            }
        }
    }
}

