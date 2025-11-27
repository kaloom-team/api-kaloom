using Kaloom.Students.Application.Extensions;
using Kaloom.Students.Application.Facades;
using Kaloom.Students.Application.Factories;
using Kaloom.Students.Application.Mappings;
using Kaloom.Students.Application.UseCases.Etecs.Delete;
using Kaloom.Students.Application.UseCases.Etecs.GetAll;
using Kaloom.Students.Application.UseCases.Etecs.GetById;
using Kaloom.Students.Application.UseCases.Etecs.Register;
using Kaloom.Students.Application.UseCases.Etecs.Update;
using Kaloom.Students.Application.UseCases.Fatecs.Delete;
using Kaloom.Students.Application.UseCases.Fatecs.GetAll;
using Kaloom.Students.Application.UseCases.Fatecs.GetById;
using Kaloom.Students.Application.UseCases.Fatecs.Register;
using Kaloom.Students.Application.UseCases.Fatecs.Update;
using Kaloom.Students.Application.UseCases.Students.Delete;
using Kaloom.Students.Application.UseCases.Students.GetAll;
using Kaloom.Students.Application.UseCases.Students.GetById;
using Kaloom.Students.Application.UseCases.Students.GetByReferenceId;
using Kaloom.Students.Application.UseCases.Students.Register;
using Kaloom.Students.Application.UseCases.Students.Update;
using Kaloom.Students.Application.UseCases.StudentsTypes.Delete;
using Kaloom.Students.Application.UseCases.StudentsTypes.GetAll;
using Kaloom.Students.Application.UseCases.StudentsTypes.GetById;
using Kaloom.Students.Application.UseCases.StudentsTypes.Register;
using Kaloom.Students.Application.UseCases.StudentsTypes.Update;
using Microsoft.Extensions.DependencyInjection;

namespace Kaloom.Students.Application.Extensions
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
            services.AddScoped<IGetStudentByReferenceIdUseCase, GetStudentByReferenceIdUseCase>();

            services.AddScoped<IStudentTypeFacade, StudentTypeFacade>();

            services.AddScoped<IStudentTypeFactory, StudentTypeFactory>();
            services.AddScoped<IStudentTypeResponseFactory, StudentTypeResponseFactory>();
            services.AddScoped<IStudentShortFactory, StudentShortFactory>();

            services.AddScoped<IInstitutionUnitResponseFactory, InstitutionUnitResponseFactory>();
            services.AddScoped<IInstitutionUnitFactory, InstitutionUnitFactory>();

            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => { }, typeof(StudentProfile));

            return services;
        }
    }
}
