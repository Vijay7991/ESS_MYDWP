// Configuration/DbContextConfiguration.cs
using DBEnity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DBEnity.Configuration
{
    public static class DbContextConfiguration
    {
        public static IServiceCollection AddDbEnityContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(connectionString));

            return services;
        }
    }
}
