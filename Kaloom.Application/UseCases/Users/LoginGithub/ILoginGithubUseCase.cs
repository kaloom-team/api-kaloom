using Kaloom.Communication.DTOs.Requests;
using Kaloom.Communication.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaloom.Application.UseCases.Users.LoginGithub
{
    public interface ILoginGithubUseCase
    {
        public Task<UserLoginResponse> ExecuteAsync(GithubLoginRequest request);
    }
}
