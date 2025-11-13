using Kaloom.API.UseCases.Users.Delete;
using Kaloom.API.UseCases.Users.GetAll;
using Kaloom.API.UseCases.Users.GetById;
using Kaloom.API.UseCases.Users.Login;
using Kaloom.API.UseCases.Users.Register;
using Kaloom.API.UseCases.Users.Update;

namespace Kaloom.API.UseCases.Users
{
    public class UsersUseCases : IUsersUseCases
    {
        public IGetAllUsersUseCase GetAll { get; set; }
        public IGetUserByIdUseCase GetById { get; set; }
        public IRegisterUserUseCase Register { get; set; }
        public IUpdateUserUseCase Update { get; set; }
        public IDeleteUserUseCase Delete { get; set; }
        public IUserLoginUseCase Login { get; set; }

        public UsersUseCases(
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
