using Kaloom.Application.UseCases.Users.Delete;
using Kaloom.Application.UseCases.Users.GetAll;
using Kaloom.Application.UseCases.Users.GetById;
using Kaloom.Application.UseCases.Users.Login;
using Kaloom.Application.UseCases.Users.Register;
using Kaloom.Application.UseCases.Users.Update;

namespace Kaloom.Application.Facades
{
    public class UserFacade : IUserFacade
    {
        public IGetAllUsersUseCase GetAll { get; set; }
        public IGetUserByIdUseCase GetById { get; set; }
        public IRegisterUserUseCase Register { get; set; }
        public IUpdateUserUseCase Update { get; set; }
        public IDeleteUserUseCase Delete { get; set; }
        public IUserLoginUseCase Login { get; set; }

        public UserFacade(
            IGetAllUsersUseCase getAll,
            IGetUserByIdUseCase getById,
            IRegisterUserUseCase register,
            IUpdateUserUseCase update,
            IDeleteUserUseCase delete,
            IUserLoginUseCase login)
        {
            this.GetAll = getAll;
            this.GetById = getById;
            this.Register = register;
            this.Update = update;
            this.Delete = delete;
            this.Login = login;
        }
    }
}
