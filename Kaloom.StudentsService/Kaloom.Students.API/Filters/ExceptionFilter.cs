using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Kaloom.Students.Communication.DTOs.Responses;
using Kaloom.Students.Exceptions.ExceptionsBase;

namespace Kaloom.Students.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _env;
        public ExceptionFilter(IHostEnvironment env)
        {
            _env = env;
        }
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is KaloomException kaloomException)
            {
                context.HttpContext.Response.StatusCode = (int)kaloomException.GetStatusCode();
                context.Result = new ObjectResult(new ErrorMessagesResponse(kaloomException.GetErrors()));
            }
            else
            {
                ThrowUnknownException(context);
            }
        }

        private void ThrowUnknownException(ExceptionContext context)
        {
            string errorMessage;

            if (_env.IsDevelopment())
            {
                errorMessage = $"ERRO DESCONHECIDO: {context.Exception.Message}\n\nStack Trace:\n{context.Exception.StackTrace}";
            }
            else
            {
                errorMessage = "ERRO DESCONHECIDO";
            }

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new ErrorMessagesResponse(errorMessage));
        }
    }
}