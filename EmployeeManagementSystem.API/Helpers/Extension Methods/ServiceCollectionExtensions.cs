using EmployeeManagementSystem.API.Core.Entities;
using EmployeeManagementSystem.API.Core.Interfaces.Services;
using EmployeeManagementSystem.API.Core.Interfaces.Services.Data_Shaping;
using EmployeeManagementSystem.API.Core.Interfaces.Services.Pagination;
using EmployeeManagementSystem.API.Core.Interfaces.Services.Repositories;
using EmployeeManagementSystem.API.Core.Interfaces.Services.Sorting;
using EmployeeManagementSystem.API.Infrastructure.Implementations.Services;
using EmployeeManagementSystem.API.Infrastructure.Implementations.Services.Data_Shaping;
using EmployeeManagementSystem.API.Infrastructure.Implementations.Services.Pagination;
using EmployeeManagementSystem.API.Infrastructure.Implementations.Services.Repositories;
using EmployeeManagementSystem.API.Infrastructure.Implementations.Services.Sorting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.API.Helpers.Extension_Methods
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped(serviceProvider =>
            {
                var actionContext = serviceProvider.GetRequiredService<IActionContextAccessor>().ActionContext;
                var factory = serviceProvider.GetRequiredService<IUrlHelperFactory>();
                return factory.GetUrlHelper(actionContext);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IJobSkillRepository, JobSkillRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();

            services.AddScoped<IPaginationService<Skill>, SkillPaginationService>();
            services.AddScoped<IRootPaginationService, RootPaginationService>();
            services.AddScoped<IDependentEntityPaginationService<Skill>, SkillPaginationService>();
            services.AddScoped<IDataShapingService<Skill>, SkillShapingService>();
            services.AddTransient<IPropertyMappingService, PropertyMappingService>();
            services.AddTransient<IPropertyCheckerService, PropertyCheckerService>();

            return services;
        }
    }
}
