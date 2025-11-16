using Kaloom.API.UseCases.Users.Delete;
using Kaloom.API.UseCases.Users.GetAll;
using Kaloom.API.UseCases.Users.GetById;
using Kaloom.API.UseCases.Users.Login;
using Kaloom.API.UseCases.Users.Register;
using Kaloom.API.UseCases.Users.Update;

namespace Kaloom.API.Facades
{
    public interface IUserFacade
    {
        public IGetAllUsersUseCase GetAll { get; }
        public IGetUserByIdUseCase GetById { get; }
        public IRegisterUserUseCase Register { get; }
        public IUpdateUserUseCase Update { get; }
        public IDeleteUserUseCase Delete { get; }
        public IUserLoginUseCase Login { get; }
    }
}
