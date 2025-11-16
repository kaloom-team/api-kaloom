using Kaloom.API.Context;
using Kaloom.API.Factories;
using Kaloom.API.Facades;
using Kaloom.API.Filters;

using Kaloom.API.UseCases.Students.Delete;
using Kaloom.API.UseCases.Students.GetAll;
using Kaloom.API.UseCases.Students.GetById;
using Kaloom.API.UseCases.Students.Register;
using Kaloom.API.UseCases.Students.Update;

using Kaloom.API.UseCases.Users.Delete;
using Kaloom.API.UseCases.Users.GetAll;
using Kaloom.API.UseCases.Users.GetById;
using Kaloom.API.UseCases.Users.Login;
using Kaloom.API.UseCases.Users.Register;
using Kaloom.API.UseCases.Users.Update;

using Kaloom.API.UseCases.Etecs.Delete;
using Kaloom.API.UseCases.Etecs.GetAll;
using Kaloom.API.UseCases.Etecs.GetById;
using Kaloom.API.UseCases.Etecs.Register;
using Kaloom.API.UseCases.Etecs.Update;

using Kaloom.API.UseCases.Fatecs.GetAll;
using Kaloom.API.UseCases.Fatecs.GetById;
using Kaloom.API.UseCases.Fatecs.Register;
using Kaloom.API.UseCases.Fatecs.Update;
using Kaloom.API.UseCases.Fatecs.Delete;

using Microsoft.EntityFrameworkCore;
using Kaloom.API.UseCases.StudentsTypes.Register;
using Kaloom.API.UseCases.StudentsTypes.GetAll;
using Kaloom.API.UseCases.StudentsTypes.GetById;
using Kaloom.API.UseCases.StudentsTypes.Delete;
using Kaloom.API.UseCases.StudentsTypes.Update;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:5173", "https://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Services.AddDbContext<KaloomContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 40))
    ));


builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IStudentFacade, StudentFacade>();
builder.Services.AddScoped<IRegisterStudentUseCase, RegisterStudentUseCase>();
builder.Services.AddScoped<IGetAllStudentsUseCase, GetAllStudentsUseCase>();
builder.Services.AddScoped<IGetStudentByIdUseCase, GetStudentByIdUseCase>();
builder.Services.AddScoped<IDeleteStudentUseCase, DeleteStudentUseCase>();
builder.Services.AddScoped<IUpdateStudentUseCase, UpdateStudentUseCase>();

builder.Services.AddScoped<IStudentTypeFacade, StudentTypeFacade>();
builder.Services.AddScoped<IRegisterStudentTypeUseCase, RegisterStudentTypeUseCase>();
builder.Services.AddScoped<IGetAllStudentsTypesUseCase, GetAllStudentsTypesUseCase>();
builder.Services.AddScoped<IGetStudentTypeByIdUseCase, GetStudentTypeByIdUseCase>();
builder.Services.AddScoped<IDeleteStudentTypeUseCase, DeleteStudentTypeUseCase>();
builder.Services.AddScoped<IUpdateStudentTypeUseCase, UpdateStudentTypeUseCase>();

builder.Services.AddScoped<IStudentTypeFactory, StudentTypeFactory>();
builder.Services.AddScoped<IStudentTypeResponseFactory, StudentTypeResponseFactory>();
builder.Services.AddScoped<IStudentShortFactory, StudentShortFactory>();

builder.Services.AddScoped<IUserFacade, UserFacade>();
builder.Services.AddScoped<IGetAllUsersUseCase, GetAllUsersUseCase>();
builder.Services.AddScoped<IGetUserByIdUseCase, GetUserByIdUseCase>();
builder.Services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
builder.Services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
builder.Services.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();
builder.Services.AddScoped<IUserLoginUseCase, UserLoginUseCase>();

builder.Services.AddScoped<IInstitutionUnitResponseFactory, InstitutionUnitResponseFactory>();
builder.Services.AddScoped<IInstitutionUnitFactory, InstitutionUnitFactory>();

builder.Services.AddScoped<IEtecFacade, EtecFacade>();
builder.Services.AddScoped<IGetAllEtecsUseCase, GetAllEtecsUseCase>();
builder.Services.AddScoped<IGetEtecByIdUseCase, GetEtecByIdUseCase>();
builder.Services.AddScoped<IRegisterEtecUseCase, RegisterEtecUseCase>();
builder.Services.AddScoped<IUpdateEtecUseCase, UpdateEtecUseCase>();
builder.Services.AddScoped<IDeleteEtecUseCase, DeleteEtecUseCase>();

builder.Services.AddScoped<IFatecFacade, FatecFacade>();
builder.Services.AddScoped<IGetAllFatecsUseCase, GetAllFatecsUseCase>();
builder.Services.AddScoped<IGetFatecByIdUseCase, GetFatecByIdUseCase>();
builder.Services.AddScoped<IRegisterFatecUseCase, RegisterFatecUseCase>();
builder.Services.AddScoped<IUpdateFatecUseCase, UpdateFatecUseCase>();
builder.Services.AddScoped<IDeleteFatecUseCase, DeleteFatecUseCase>();

builder.Services.AddMvc(option => option.Filters.Add(typeof(ExceptionFilter)));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
