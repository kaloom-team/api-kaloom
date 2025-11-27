using Kaloom.Users.Application.UseCases.Users.Delete;
using Kaloom.Users.Application.UseCases.Users.GetAll;
using Kaloom.Users.Application.UseCases.Users.GetById;
using Kaloom.Users.Application.UseCases.Users.Login;
using Kaloom.Users.Application.UseCases.Users.LoginGithub;
using Kaloom.Users.Application.UseCases.Users.LoginGoogle;
using Kaloom.Users.Application.UseCases.Users.Register;
using Kaloom.Users.Application.UseCases.Users.Update;

namespace Kaloom.Users.Application.Facades
{
    public interface IUserFacade
    {
        public IGetAllUsersUseCase GetAll { get; }
        public IGetUserByIdUseCase GetById { get; }
        public IRegisterUserUseCase Register { get; }
        public IUpdateUserUseCase Update { get; }
        public IDeleteUserUseCase Delete { get; }
        public IUserLoginUseCase Login { get; }
        public ILoginGoogleUseCase LoginGoogle { get; }
        public ILoginGithubUseCase LoginGithub { get; }
    }
}
