using Kaloom.API.UseCases.Students.Update;
using Kaloom.API.UseCases.Users.Delete;
using Kaloom.API.UseCases.Users.GetAll;
using Kaloom.API.UseCases.Users.GetById;
using Kaloom.API.UseCases.Users.Register;
using Kaloom.API.UseCases.Users.Update;
using Kaloom.API.UseCases.Users.Login;

namespace Kaloom.API.UseCases.Users
{
    public interface IUsersUseCases
    {
        public IGetAllUsersUseCase GetAll { get; set; }
        public IGetUserByIdUseCase GetById { get; set; }
        public IRegisterUserUseCase Register { get; set; }
        public IUpdateUserUseCase Update { get; set; }
        public IDeleteUserUseCase Delete { get; set; }
        public IUserLoginUseCase Login { get; set; }
    }
}
