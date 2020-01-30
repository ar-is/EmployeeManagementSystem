using Employee_Management_System.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management_System.Infrastructure.EntityConfigurations
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            ConfigureKeysAndIndexes(builder);
            ConfigurePropertiesAttributes(builder);
            ConfigureEntityRelationships(builder);
            SeedData(builder);
        }

        private void ConfigureKeysAndIndexes(EntityTypeBuilder<Job> builder)
        {
            builder
                .HasIndex(j => j.Guid)
                .HasName("Guid")
                .IsClustered(false);
        }

        private void ConfigurePropertiesAttributes(EntityTypeBuilder<Job> builder)
        {
            builder.Property(j => j.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(j => j.Description)
                .IsRequired()
                .HasMaxLength(500);
        }

        private void ConfigureEntityRelationships(EntityTypeBuilder<Job> builder)
        {
            builder
                .HasOne(j => j.Department)
                .WithMany(d => d.Jobs)
                .HasForeignKey(j => j.DepartmentId);
        }

        private void SeedData(EntityTypeBuilder<Job> builder)
        {
            builder.HasData(
                 new Job
                 {
                     Id = 1,
                     Guid = Guid.Parse("7b75a444-994d-4936-96bf-9c3c0804e42d"),
                     Title = "Logistics Specialist",
                     SeniorityLevel = JobSeniorityLevel.Mid,
                     Description = "A logistics specialist is responsible for the oversight of the life cycle of products, including preparation, shipping and receiving.",
                     DepartmentId = 1
                 },
                 new Job
                 {
                     Id = 2,
                     Guid = Guid.Parse("a51f9b12-fb95-43e2-b010-733d53faf235"),
                     Title = "Logistics Coordinator",
                     SeniorityLevel = JobSeniorityLevel.Senior,
                     Description = "A logistics coordinator is responsible for managing all aspects of shipping routes and delivery, specifically with regard to customer satisfaction.",
                     DepartmentId = 1
                 },
                 new Job
                 {
                     Id = 3,
                     Guid = Guid.Parse("4d459461-59da-473d-938e-f5c7c03d12d7"),
                     Title = ".NET Software Developer",
                     SeniorityLevel = JobSeniorityLevel.Junior,
                     Description = "A Junior Software Developer serves as a member of the software development team, aiding in the innovation and creation of company software and programs.",
                     DepartmentId = 2
                 },
                 new Job
                 {
                     Id = 4,
                     Guid = Guid.Parse("5c4a34ac-be45-4419-8a8b-612c020b38cf"),
                     Title = ".NET Software Developer",
                     SeniorityLevel = JobSeniorityLevel.Senior,
                     Description = "A Senior Software Developer serves as a leading member of the software development team, architecting towards innovation and creation of company software and programs.",
                     DepartmentId = 2
                 },
                 new Job
                 {
                     Id = 5,
                     Guid = Guid.Parse("905d1d8f-d286-4ef2-a72e-c76353f342cb"),
                     Title = "IT Specialist",
                     SeniorityLevel = JobSeniorityLevel.Senior,
                     Description = "IT Specialists, or Information Technology Specialists, install, monitor, and troubleshoot computer hardware and software systems.",
                     DepartmentId = 2
                 },
                 new Job
                 {
                     Id = 6,
                     Guid = Guid.Parse("ca6a17f8-2045-4113-bbdb-3230427ae5cd"),
                     Title = "Talent Acquisition Recruiter",
                     SeniorityLevel = JobSeniorityLevel.Mid,
                     Description = "A talent acquisition specialist is an HR professional who specializes in sourcing, identifying and hiring specific types of employees.",
                     DepartmentId = 3
                 },
                 new Job
                 {
                     Id = 7,
                     Guid = Guid.Parse("d64e4e3c-6d5b-4818-9039-246861177572"),
                     Title = "HR Specialist",
                     SeniorityLevel = JobSeniorityLevel.Senior,
                     Description = "The responsibilities of human resources specialists revolve around the recruitment and placement of employees; therefore, their job duties may range from screening job candidates and conducting interviews to performing background checks and providing orientation to new employees.",
                     DepartmentId = 3
                 }
                 );
        }
    }
}
