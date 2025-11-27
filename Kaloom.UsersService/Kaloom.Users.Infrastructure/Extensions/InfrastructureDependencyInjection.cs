using Kaloom.Users.Application.Services.Abstractions;
using Kaloom.Users.Domain.Repositories.Abstractions;
using Kaloom.Users.Infrastructure.Data.Context;
using Kaloom.Users.Infrastructure.Messaging;
using Kaloom.Users.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kaloom.Users.Infrastructure.Extensions
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<UsersContext>(options =>
                options.UseMySql(
                    configuration.GetConnectionString("DefaultConnection"),
                    new MySqlServerVersion(new Version(8, 0, 40))
                ));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
