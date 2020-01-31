using EmployeeManagementSystem.WebClient.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.WebClient.Helpers.Extension_Methods
{
    public static class IHostExtensions
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using var scope = host.Services.CreateScope();

            using var context = scope.ServiceProvider.GetService<EMSWebClientDbContext>();

            try
            {
                //context.Database.EnsureDeleted();
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }

            return host;
        }
    }
}
