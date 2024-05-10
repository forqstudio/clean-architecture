using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Bookify.Application.Abstractions.Clock;
using Bookify.Infrastructure.Clock;
using Bookify.Application.Abstractions.Email;
using Bookify.Infrastructure.Email;
using Microsoft.EntityFrameworkCore;
using Bookify.Domain.Apartments;
using Bookify.Infrastructure.Repositories;
using Bookify.Domain.Users;
using Bookify.Domain.Bookings;
using Bookify.Domain.Abstractions;
using Bookify.Application.Abstractions.Data;
using Bookify.Infrastructure.Data;
using Dapper;

namespace Bookify.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // services
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();
            services.AddTransient<IEmailService, EmailService>();

            // entity framework
            string connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException("DefaultConnection is not found in the configuration");
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
            });

            // dapper
            services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));
            SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

            // repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<ApplicationDbContext>());

            return services;
        }
    }
}
