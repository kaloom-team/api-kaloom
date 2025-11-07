using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaloom.Communication.DTOs.Responses
{
    public class ErrorMessagesResponse
    {
        public List<string> Errors { get; private set; }
         public ErrorMessagesResponse(string message)
        {
            Errors = [message];
        }
        public ErrorMessagesResponse(List<string> messages)
        {
            Errors = messages;
        }
    }
}