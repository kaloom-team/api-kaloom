using Kaloom.Users.Application.UseCases.Users.Delete;
using Kaloom.Users.Application.UseCases.Users.GetAll;
using Kaloom.Users.Application.UseCases.Users.GetById;
using Kaloom.Users.Application.UseCases.Users.Login;
using Kaloom.Users.Application.UseCases.Users.LoginGithub;
using Kaloom.Users.Application.UseCases.Users.LoginGoogle;
using Kaloom.Users.Application.UseCases.Users.Register;
using Kaloom.Users.Application.UseCases.Users.Update;
using Kaloom.Users.Application.Extensions;
using Kaloom.Users.Application.Facades;
using Kaloom.Users.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace Kaloom.Users.Application.Extensions
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            

            services.AddScoped<IGetAllUsersUseCase, GetAllUsersUseCase>();
            services.AddScoped<IGetUserByIdUseCase, GetUserByIdUseCase>();
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
            services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
            services.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();
            services.AddScoped<IUserLoginUseCase, UserLoginUseCase>();
            services.AddScoped<ILoginGoogleUseCase, LoginGoogleUseCase>();
            services.AddScoped<ILoginGithubUseCase, LoginGithubUseCase>();

            services.AddScoped<IUserFacade, UserFacade>();

            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => { }, typeof(UserProfile));

            return services;
        }
    }
}
