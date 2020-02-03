using EmployeeManagementSystem.WebClient.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.WebClient.Infrastructure.Entity_Configurations
{
    public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
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
            builder.HasData(
                new ApplicationRole
                {
                    Id = 1,
                    Guid = Guid.Parse("a81e61ce-607f-43fd-ad39-fd6c6d784730"),
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new ApplicationRole
                {
                    Id = 2,
                    Guid = Guid.Parse("62714b07-3dd0-4a27-9a76-b13fb1815451"),
                    Name = "Scheduler",
                    NormalizedName = "SCHEDULER"
                });
        }
    }
}
