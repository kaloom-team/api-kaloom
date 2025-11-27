using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace Kaloom.Students.Exceptions.ExceptionsBase
{
    public class NotFoundException : KaloomException
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public override List<string> GetErrors() => [Message];
        public override HttpStatusCode GetStatusCode() => HttpStatusCode.NotFound;
    }
}