using Kaloom.Communication.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaloom.Application.Services
{
    public interface IGoogleAuthService
    {
        public Task<ExternalAuthData> ValidateAsync(string code);
    }
}
