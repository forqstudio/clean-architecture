using Bookify.Api.Middleware;
using Bookify.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Api.Extensions
{
    internal static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder builder)
        {
            using var scope = builder.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            dbContext.Database.Migrate();

            return builder;
        }

        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionHandlingMiddleware>();

            return builder;
        }

        public static IApplicationBuilder UseRequestContextLogging(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<RequestContextLoggingMiddleware>();
            
            return builder;
        }
    }
}
