using Kaloom.Application.UseCases.Users.Delete;
using Kaloom.Application.UseCases.Users.GetAll;
using Kaloom.Application.UseCases.Users.GetById;
using Kaloom.Application.UseCases.Users.Login;
using Kaloom.Application.UseCases.Users.LoginGoogle;
using Kaloom.Application.UseCases.Users.Register;
using Kaloom.Application.UseCases.Users.Update;

namespace Kaloom.Application.Facades
{
    public class UserFacade : IUserFacade
    {
        public IGetAllUsersUseCase GetAll { get; }
        public IGetUserByIdUseCase GetById { get; }
        public IRegisterUserUseCase Register { get; }
        public IUpdateUserUseCase Update { get; }
        public IDeleteUserUseCase Delete { get; }
        public IUserLoginUseCase Login { get; }
        public ILoginGoogleUseCase LoginGoogle { get; }


        public UserFacade(
            IGetAllUsersUseCase getAll,
            IGetUserByIdUseCase getById,
            IRegisterUserUseCase register,
            IUpdateUserUseCase update,
            IDeleteUserUseCase delete,
            IUserLoginUseCase login,
            ILoginGoogleUseCase loginGoogle)
        {
            this.GetAll = getAll;
            this.GetById = getById;
            this.Register = register;
            this.Update = update;
            this.Delete = delete;
            this.Login = login;
            this.LoginGoogle = loginGoogle;
        }
    }
}
