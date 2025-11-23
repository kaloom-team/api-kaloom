using Kaloom.Domain.Repositories.Abstractions;
using Kaloom.Infrastructure.Data.Context;
using Kaloom.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kaloom.Infrastructure.Extensions
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<KaloomContext>(options =>
                options.UseMySql(
                    configuration.GetConnectionString("DefaultConnection"),
                    new MySqlServerVersion(new Version(8, 0, 40))
                ));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IEtecRepository, EtecRepository>();
            services.AddScoped<IFatecRepository, FatecRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentTypeRepository, StudentTypeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
