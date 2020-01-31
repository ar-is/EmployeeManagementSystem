using EmployeeManagementSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.Infrastructure.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            ConfigureKeysAndIndexes(builder);
            ConfigurePropertiesAttributes(builder);
            ConfigureEntityRelationships(builder);
            SeedData(builder);
        }

        private void ConfigureKeysAndIndexes(EntityTypeBuilder<Employee> builder)
        {
            builder
                .HasIndex(e => e.Guid)
                .HasName("Guid")
                .IsClustered(false);
        }

        private void ConfigurePropertiesAttributes(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Surname)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(14);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(254);
        }

        private void ConfigureEntityRelationships(EntityTypeBuilder<Employee> builder)
        {
            builder
                .HasOne(e => e.Job)
                .WithMany(j => j.Employees)
                .HasForeignKey(e => e.JobId);
        }

        private void SeedData(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                 new Employee
                 {
                     Id = 1,
                     Guid = Guid.Parse("9dbc5eeb-6a83-46f9-92a4-23d8253f36cc"),
                     Name = "Georgios",
                     Surname = "Papadimitriou",
                     HiringDate = new DateTime(2019, 09, 20),
                     PhoneNumber = "2104444444",
                     Email = "george.papadimitriou@company.com",
                     JobId = 3,
                     LatestSkillsetUpdate = new DateTime(2020, 01, 30),
                     LatestUpdate = new DateTime(2020, 01, 30)
                 },
                 new Employee
                 {
                     Id = 2,
                     Guid = Guid.Parse("42bff182-7a27-4afb-b416-6ddec070a26f"),
                     Name = "Dimitrios",
                     Surname = "Konstantinou",
                     HiringDate = new DateTime(2017, 04, 15),
                     PhoneNumber = "2105555555",
                     Email = "dimitrios.konstantinou@company.com",
                     JobId = 5,
                     LatestSkillsetUpdate = new DateTime(2020, 01, 30),
                     LatestUpdate = new DateTime(2020, 01, 30)
                 },
                 new Employee
                 {
                     Id = 3,
                     Guid = Guid.Parse("a4c16623-aa97-4846-93e5-6fdd3c486f0f"),
                     Name = "Eleni",
                     Surname = "Dimitriou",
                     HiringDate = new DateTime(2017, 02, 10),
                     PhoneNumber = "2105555555",
                     Email = "eleni.dimitriou@company.com",
                     JobId = 2,
                     LatestSkillsetUpdate = new DateTime(2020, 01, 30),
                     LatestUpdate = new DateTime(2020, 01, 30)
                 },
                 new Employee
                 {
                     Id = 4,
                     Guid = Guid.Parse("2dcd69bf-d4bb-4964-afd0-5d6481a5028f"),
                     Name = "John",
                     Surname = "Dunham",
                     HiringDate = new DateTime(2017, 08, 02),
                     PhoneNumber = "2106666666",
                     Email = "john.dunham@company.com",
                     JobId = 4,
                     LatestSkillsetUpdate = new DateTime(2020, 01, 30),
                     LatestUpdate = new DateTime(2020, 01, 30)
                 },
                 new Employee
                 {
                     Id = 5,
                     Guid = Guid.Parse("14924b4e-8f1f-4221-b476-d850fb7147be"),
                     Name = "Konstantina",
                     Surname = "Nikolaou",
                     HiringDate = new DateTime(2020, 01, 15),
                     PhoneNumber = "2107777777",
                     Email = "konstantina.nikolaou@company.com",
                     JobId = 6,
                     LatestSkillsetUpdate = new DateTime(2020, 01, 30),
                     LatestUpdate = new DateTime(2020, 01, 30)
                 },
                 new Employee
                 {
                     Id = 6,
                     Guid = Guid.Parse("517f9706-11ca-4de9-8c94-05446aa07071"),
                     Name = "Amy",
                     Surname = "Roberts",
                     HiringDate = new DateTime(2017, 03, 11),
                     PhoneNumber = "2108888888",
                     Email = "amy.roberts@company.com",
                     JobId = 3,
                     LatestSkillsetUpdate = new DateTime(2020, 01, 30),
                     LatestUpdate = new DateTime(2020, 01, 30)
                 },
                 new Employee
                 {
                     Id = 7,
                     Guid = Guid.Parse("ec458a9c-3abb-42ff-99dd-03e2ad93206d"),
                     Name = "Petros",
                     Surname = "Stamatopoulos",
                     HiringDate = new DateTime(2019, 05, 21),
                     PhoneNumber = "2109999999",
                     Email = "petros.stamatopoulos@company.com",
                     JobId = 3,
                     LatestSkillsetUpdate = new DateTime(2020, 01, 30),
                     LatestUpdate = new DateTime(2020, 01, 30)
                 },
                 new Employee
                 {
                     Id = 8,
                     Guid = Guid.Parse("ce0de968-74e5-49cc-8f8b-e32b5ab6c8dc"),
                     Name = "Katerina",
                     Surname = "Kastriti",
                     HiringDate = new DateTime(2019, 03, 27),
                     PhoneNumber = "2101234567",
                     Email = "katerina.kastriti@company.com",
                     JobId = 1,
                     LatestSkillsetUpdate = new DateTime(2020, 01, 30),
                     LatestUpdate = new DateTime(2020, 01, 30)
                 }
                 );
        }
    }
}
