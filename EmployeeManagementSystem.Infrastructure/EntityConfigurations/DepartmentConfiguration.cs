using EmployeeManagementSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.Infrastructure.EntityConfigurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            ConfigureKeysAndIndexes(builder);
            ConfigurePropertiesAttributes(builder);
            ConfigureEntityRelationships(builder);
            SeedData(builder);
        }

        private void ConfigureKeysAndIndexes(EntityTypeBuilder<Department> builder)
        {
            builder
                .HasIndex(d => d.Guid)
                .HasName("Guid")
                .IsClustered(false);
        }

        private void ConfigurePropertiesAttributes(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(d => d.PhoneNumber)
                .IsRequired()
                .HasMaxLength(14);

            builder.Property(d => d.Email)
                .IsRequired()
                .HasMaxLength(254);
        }

        private void ConfigureEntityRelationships(EntityTypeBuilder<Department> builder)
        {
            builder
                .HasOne(d => d.Manager)
                .WithMany()
                .HasForeignKey(d => d.ManagerId)
                .IsRequired(false);
        }

        private void SeedData(EntityTypeBuilder<Department> builder)
        {
            builder.HasData(
                 new Department
                 {
                     Id = 1,
                     Guid = Guid.Parse("a9eb16c3-d4d6-4280-89ad-8e1bba35be38"),
                     Name = "Logistics",
                     Description = "Logistics management is that part of the supply chain which plans, implements and controls the efficient, effective forward and reverse flow and storage of goods, services and related information between the point of origin and the point of consumption in order to meet customers' requirements.",
                     PhoneNumber = "2101111111",
                     Email = "logistics@company.com"
                 },
                 new Department
                 {
                     Id = 2,
                     Guid = Guid.Parse("344ac739-b7ff-4b50-916b-77882688be7c"),
                     Name = "Software Development",
                     Description = "Software Development team specializes in the development of custom software applications and offshore software outsourcing services.",
                     PhoneNumber = "2102222222",
                     Email = "swdev@company.com"
                 },
                 new Department
                 {
                     Id = 3,
                     Guid = Guid.Parse("8a113a93-2051-490d-9329-bad2920e9b97"),
                     Name = "Human Resources (HR)",
                     Description = "Human resources or HR is the department charged with finding, screening, recruiting, and training job applicants, and administering employee-benefit programs",
                     Email = "hr@company.com",
                     PhoneNumber = "2103333333"
                 }                
                 );
        }
    }
}
