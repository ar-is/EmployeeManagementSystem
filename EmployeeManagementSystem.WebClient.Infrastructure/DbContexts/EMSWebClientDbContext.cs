using EmployeeManagementSystem.WebClient.Core.Entities;
using EmployeeManagementSystem.WebClient.Infrastructure.Entity_Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.WebClient.Infrastructure.DbContexts
{
    public class EMSWebClientDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public EMSWebClientDbContext(DbContextOptions<EMSWebClientDbContext> options)
            : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ApplicationUserConfiguration());
        }
    }
}
