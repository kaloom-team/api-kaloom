using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace Kaloom.Students.Exceptions.ExceptionsBase
{
    public abstract class KaloomException : SystemException
    {
        public KaloomException(string errorMessage) : base(errorMessage)
        {
        }

        public abstract List<string> GetErrors();
        public abstract HttpStatusCode GetStatusCode();
    }
}