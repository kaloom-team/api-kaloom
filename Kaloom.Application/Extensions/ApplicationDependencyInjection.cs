using Kaloom.API.Mappings;
using Kaloom.Application.Facades;
using Kaloom.Application.Factories;
using Kaloom.Application.UseCases.Etecs.Delete;
using Kaloom.Application.UseCases.Etecs.GetAll;
using Kaloom.Application.UseCases.Etecs.GetById;
using Kaloom.Application.UseCases.Etecs.Register;
using Kaloom.Application.UseCases.Etecs.Update;
using Kaloom.Application.UseCases.Fatecs.Delete;
using Kaloom.Application.UseCases.Fatecs.GetAll;
using Kaloom.Application.UseCases.Fatecs.GetById;
using Kaloom.Application.UseCases.Fatecs.Register;
using Kaloom.Application.UseCases.Fatecs.Update;
using Kaloom.Application.UseCases.Students.Delete;
using Kaloom.Application.UseCases.Students.GetAll;
using Kaloom.Application.UseCases.Students.GetById;
using Kaloom.Application.UseCases.Students.Register;
using Kaloom.Application.UseCases.Students.Update;
using Kaloom.Application.UseCases.StudentsTypes.Delete;
using Kaloom.Application.UseCases.StudentsTypes.GetAll;
using Kaloom.Application.UseCases.StudentsTypes.GetById;
using Kaloom.Application.UseCases.StudentsTypes.Register;
using Kaloom.Application.UseCases.StudentsTypes.Update;
using Kaloom.Application.UseCases.Users.Delete;
using Kaloom.Application.UseCases.Users.GetAll;
using Kaloom.Application.UseCases.Users.GetById;
using Kaloom.Application.UseCases.Users.Login;
using Kaloom.Application.UseCases.Users.LoginGoogle;
using Kaloom.Application.UseCases.Users.Register;
using Kaloom.Application.UseCases.Users.Update;
using Microsoft.Extensions.DependencyInjection;

namespace Kaloom.Application.Extensions
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IGetAllEtecsUseCase, GetAllEtecsUseCase>();
            services.AddScoped<IGetEtecByIdUseCase, GetEtecByIdUseCase>();
            services.AddScoped<IRegisterEtecUseCase, RegisterEtecUseCase>();
            services.AddScoped<IUpdateEtecUseCase, UpdateEtecUseCase>();
            services.AddScoped<IDeleteEtecUseCase, DeleteEtecUseCase>();

            services.AddScoped<IEtecFacade, EtecFacade>();

            services.AddScoped<IGetAllFatecsUseCase, GetAllFatecsUseCase>();
            services.AddScoped<IGetFatecByIdUseCase, GetFatecByIdUseCase>();
            services.AddScoped<IRegisterFatecUseCase, RegisterFatecUseCase>();
            services.AddScoped<IUpdateFatecUseCase, UpdateFatecUseCase>();
            services.AddScoped<IDeleteFatecUseCase, DeleteFatecUseCase>();

            services.AddScoped<IFatecFacade, FatecFacade>();

            services.AddScoped<IGetAllStudentsUseCase, GetAllStudentsUseCase>();
            services.AddScoped<IGetStudentByIdUseCase, GetStudentByIdUseCase>();
            services.AddScoped<IRegisterStudentUseCase, RegisterStudentUseCase>();
            services.AddScoped<IUpdateStudentUseCase, UpdateStudentUseCase>();
            services.AddScoped<IDeleteStudentUseCase, DeleteStudentUseCase>();

            services.AddScoped<IStudentFacade, StudentFacade>();

            services.AddScoped<IGetAllStudentsTypesUseCase, GetAllStudentsTypesUseCase>();
            services.AddScoped<IGetStudentTypeByIdUseCase, GetStudentTypeByIdUseCase>();
            services.AddScoped<IRegisterStudentTypeUseCase, RegisterStudentTypeUseCase>();
            services.AddScoped<IUpdateStudentTypeUseCase, UpdateStudentTypeUseCase>();
            services.AddScoped<IDeleteStudentTypeUseCase, DeleteStudentTypeUseCase>();

            services.AddScoped<IStudentTypeFacade, StudentTypeFacade>();

            services.AddScoped<IGetAllUsersUseCase, GetAllUsersUseCase>();
            services.AddScoped<IGetUserByIdUseCase, GetUserByIdUseCase>();
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
            services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
            services.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();
            services.AddScoped<IUserLoginUseCase, UserLoginUseCase>();
            services.AddScoped<ILoginGoogleUseCase, LoginGoogleUseCase>();

            services.AddScoped<IUserFacade, UserFacade>();

            services.AddScoped<IStudentTypeFactory, StudentTypeFactory>();
            services.AddScoped<IStudentTypeResponseFactory, StudentTypeResponseFactory>();
            services.AddScoped<IStudentShortFactory, StudentShortFactory>();

            services.AddScoped<IInstitutionUnitResponseFactory, InstitutionUnitResponseFactory>();
            services.AddScoped<IInstitutionUnitFactory, InstitutionUnitFactory>();

            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => { }, typeof(StudentProfile), typeof(UserProfile));

            return services;
        }
    }
}
