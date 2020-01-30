using Employee_Management_System.Core.Interfaces.Services;
using Employee_Management_System.Core.Interfaces.Services.Repositories;
using Employee_Management_System.Infrastructure.Implementations.Services;
using Employee_Management_System.Infrastructure.Implementations.Services.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management_System.API.Helpers.Extension_Methods
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IJobSkillRepository, JobSkillRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();

            return services;
        }
    }
}
