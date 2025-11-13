using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kaloom.Exceptions.ExceptionsBase
{
    public class UnauthorizedException : KaloomException
    {
        public UnauthorizedException(string message) : base(message)
        {
        }

        public override List<string> GetErrors() => [Message];
        public override HttpStatusCode GetStatusCode() => HttpStatusCode.Unauthorized;
    }
}
