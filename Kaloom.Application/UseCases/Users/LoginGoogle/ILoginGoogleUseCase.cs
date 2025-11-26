using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaloom.Application.UseCases.Users.LoginGoogle
{
    public interface ILoginGoogleUseCase
    {
        public Task<UserLoginResponse> ExecuteAsync(GoogleLoginRequest request);
    }
}
