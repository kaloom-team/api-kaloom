using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace Kaloom.Exceptions.ExceptionsBase
{
    public class ErrorOnValidationException : KaloomException
    {
        private readonly List<string> _errors;

        public ErrorOnValidationException(List<string> errorsMessages) : base("Erro de validação")
        {
            _errors = errorsMessages;
        }

        public ErrorOnValidationException(string errorsMessages) : base("Erro de validação")
        {
            _errors = [errorsMessages];
        }

        public override List<string> GetErrors() => _errors;

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
    }
}