using EmployeeManagementSystem.WebClient.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.WebClient.Infrastructure.Entity_Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            ConfigureKeysAndIndexes(builder);
            SeedData(builder);
        }

        private void ConfigureKeysAndIndexes(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder
                .HasIndex(u => u.Guid)
                .HasName("Guid")
                .IsClustered(false);
        }

        private void SeedData(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder
                .HasData(
            new IdentityRole
            {
                Name = "Scheduler",
                NormalizedName = "SCHEDULER"
            },
            new IdentityRole
            {
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            });
        }
    }
}
