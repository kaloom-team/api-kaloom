using Kaloom.Users.Communication.DTOs.Requests;
using Kaloom.Users.Communication.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaloom.Users.Application.UseCases.Users.LoginGithub
{
    public interface ILoginGithubUseCase
    {
        public Task<UserLoginResponse> ExecuteAsync(GithubLoginRequest request);
    }
}
