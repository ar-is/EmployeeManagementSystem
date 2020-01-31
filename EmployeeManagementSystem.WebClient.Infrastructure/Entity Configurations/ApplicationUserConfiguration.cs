using EmployeeManagementSystem.WebClient.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.WebClient.Infrastructure.Entity_Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            ConfigureKeysAndIndexes(builder);           
        }

        private void ConfigureKeysAndIndexes(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .HasIndex(u => u.Guid)
                .HasName("Guid")
                .IsClustered(false);
        }
    }
}
