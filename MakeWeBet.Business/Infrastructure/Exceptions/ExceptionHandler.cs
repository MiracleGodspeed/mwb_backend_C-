using MakeWeBet.Business.Interface;
using MakeWeBet.Data.Enums;
using MakeWeBet.Data.Models.ExceptionModels;
using MakeWeBet.Data.Models.Response;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Business.Infrastructure.Exceptions
{
    public static class ExceptionHandler
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerManager logger, IWebHostEnvironment env)
        {

            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Response.ContentType = "application/json";

                    IExceptionHandlerFeature contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.LogError($"Something went wrong: {contextFeature.Error}");

                        if (contextFeature.Error.GetType() == typeof(InvalidOperationException) ||
                            contextFeature.Error.GetType() == typeof(NotFoundException) ||
                            contextFeature.Error.GetType() == typeof(ArgumentException))

                        {

                            await context.Response.WriteAsync(new ErrorDetails
                            {
                                Status = ResponseStatus.APP_ERROR,
                                Message = contextFeature.Error.Message

                            }.ToString());

                        }
                        else
                        {
                            await context.Response.WriteAsync(new ErrorDetails
                            {
                                Status = ResponseStatus.FATAL_ERROR,
                                Message = "Oops, Something Went Wrong"
                            }.ToString());
                        }
                    }
                });
            });
        }

    }
}
