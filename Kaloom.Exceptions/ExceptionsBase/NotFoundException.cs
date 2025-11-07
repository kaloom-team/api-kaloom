using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace Kaloom.Exceptions.ExceptionsBase
{
    public class NotFoundException : SystemException
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public List<string> GetErrors() => [Message];
        public HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
    }
}