using Kaloom.API.Context;
using Kaloom.API.Factories;
using Kaloom.API.Filters;
using Kaloom.API.UseCases.Students;
using Kaloom.API.UseCases.Students.Delete;
using Kaloom.API.UseCases.Students.GetAll;
using Kaloom.API.UseCases.Students.GetById;
using Kaloom.API.UseCases.Students.Register;
using Kaloom.API.UseCases.Students.Update;
using Kaloom.API.UseCases.Users;
using Kaloom.API.UseCases.Users.Delete;
using Kaloom.API.UseCases.Users.GetAll;
using Kaloom.API.UseCases.Users.GetById;
using Kaloom.API.UseCases.Users.Login;
using Kaloom.API.UseCases.Users.Register;
using Kaloom.API.UseCases.Users.Update;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

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

builder.Services.AddScoped<IStudentsUseCases, StudentsUseCases>();
builder.Services.AddScoped<IRegisterStudentUseCase, RegisterStudentUseCase>();
builder.Services.AddScoped<IGetAllStudentsUseCase, GetAllStudentsUseCase>();
builder.Services.AddScoped<IGetStudentByIdUseCase, GetStudentByIdUseCase>();
builder.Services.AddScoped<IDeleteStudentUseCase, DeleteStudentUseCase>();
builder.Services.AddScoped<IUpdateStudentUseCase, UpdateStudentUseCase>();

builder.Services.AddScoped<IStudentShortFactory, StudentShortFactory>();

builder.Services.AddScoped<IUsersUseCases, UsersUseCases>();
builder.Services.AddScoped<IGetAllUsersUseCase, GetAllUsersUseCase>();
builder.Services.AddScoped<IGetUserByIdUseCase, GetUserByIdUseCase>();
builder.Services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
builder.Services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
builder.Services.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();
builder.Services.AddScoped<IUserLoginUseCase, UserLoginUseCase>();

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
