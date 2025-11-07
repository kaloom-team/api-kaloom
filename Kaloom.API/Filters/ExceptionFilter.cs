using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Kaloom.Exceptions.ExceptionsBase;
using Kaloom.Communication.DTOs.Responses;

namespace Kaloom.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
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
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new ErrorMessagesResponse("ERRO DESCONHECIDO"));
        }
    }
}