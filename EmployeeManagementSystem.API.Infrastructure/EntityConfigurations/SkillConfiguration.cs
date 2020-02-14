using EmployeeManagementSystem.API.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.API.Infrastructure.EntityConfigurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            ConfigureKeysAndIndexes(builder);
            ConfigurePropertiesAttributes(builder);
            SeedData(builder);
        }

        private void ConfigureKeysAndIndexes(EntityTypeBuilder<Skill> builder)
        {
            builder
                .HasIndex(s => s.Guid)
                .HasName("Guid")
                .IsClustered(false);
        }

        private void ConfigurePropertiesAttributes(EntityTypeBuilder<Skill> builder)
        {
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(500);
        }

        private void SeedData(EntityTypeBuilder<Skill> builder)
        {
            builder.HasData(
                 new Skill
                 {
                     Id = 1,
                     Guid = Guid.Parse("57408e9a-9d0a-4df9-87df-fc4dbc8ab9e5"),
                     Name = "Communication",
                     Type = SkillType.Soft,
                     IsEnabled = true,
                     CreationDate = new DateTime(2020, 01, 30),
                     Description = "Effective communication skills will be helpful through the interview process and in your career overall. The ability to communicate involves knowing how you should speak to others in different situations or settings."
                 },
                 new Skill
                 {
                     Id = 2,
                     Guid = Guid.Parse("6bd53075-c359-4723-88e6-e942d04af82b"),
                     Name = "Problem-solving",
                     Type = SkillType.Soft,
                     IsEnabled = true,
                     CreationDate = new DateTime(2020, 01, 30),
                     Description = "Employers highly value people who can resolve issues quickly and effectively. That may involve calling on industry knowledge to fix an issue immediately as it occurs, or taking time to research and consult with colleagues to find a scalable, long-term solution."
                 },
                 new Skill
                 {
                     Id = 3,
                     Guid = Guid.Parse("35534cb4-3e59-4edb-ab8d-da73caece421"),
                     Name = "Creativity",
                     Type = SkillType.Soft,
                     IsEnabled = true,
                     CreationDate = new DateTime(2020, 01, 30),
                     Description = "Employees with creativity can find new ways to perform tasks, improve processes or even develop new and exciting avenues for the business to explore."
                 },
                 new Skill
                 {
                     Id = 4,
                     Guid = Guid.Parse("d69b8478-b06a-4469-8540-4f0bffd9a3a1"),
                     Name = "Adaptability",
                     Type = SkillType.Soft,
                     IsEnabled = true,
                     CreationDate = new DateTime(2020, 01, 30),
                     Description = "Employees who are capable of adapting to new situations and ways of working are valuable in many jobs and industries."
                 },
                 new Skill
                 {
                     Id = 5,
                     Guid = Guid.Parse("8a113a93-2051-490d-9329-bad2920e9b97"),
                     Name = "Work ethic",
                     Type = SkillType.Soft,
                     IsEnabled = true,
                     CreationDate = new DateTime(2020, 01, 30),
                     Description = "Work ethic is the ability to follow through on tasks and duties in a timely, quality manner. A strong work ethic will help ensure you develop a positive relationship with your employer and colleagues, even when you are still developing technical skills in a new job."
                 },
                 new Skill
                 {
                     Id = 6,
                     Guid = Guid.Parse("5dc15297-6522-4363-9c1f-c78b597eb73e"),
                     Name = "Data Structures and Algorithms",
                     Type = SkillType.Technical,
                     IsEnabled = true,
                     CreationDate = new DateTime(2020, 01, 30),
                     Description = "Data Structures and Algorithms(e.g. array, linked list, tree) are the heart of programming as they improve the problem-solving ability of a candidate/employee to a great extent."
                 },
                 new Skill
                 {
                     Id = 7,
                     Guid = Guid.Parse("1811edf9-c04b-4a09-80a9-8c28538a732c"),
                     Name = "Source Control (Git, TFS, etc.)",
                     Type = SkillType.Technical,
                     IsEnabled = true,
                     CreationDate = new DateTime(2020, 01, 30),
                     Description = "Source control helps the developer in managing and storing their code."
                 },
                 new Skill
                 {
                     Id = 8,
                     Guid = Guid.Parse("caaf4435-c6de-436d-a941-8bf3f8d9ce38"),
                     Name = "OOP",
                     Type = SkillType.Technical,
                     IsEnabled = true,
                     CreationDate = new DateTime(2020, 01, 30),
                     Description = "OOP defines most modern server-side scripting languages, which are the languages back-end developers use to write software and database technology."
                 },
                 new Skill
                 {
                     Id = 9,
                     Guid = Guid.Parse("7fde5249-3a4a-4b95-b8fc-81bc78cf848e"),
                     Name = "C#",
                     Type = SkillType.Technical,
                     IsEnabled = true,
                     CreationDate = new DateTime(2020, 01, 30),
                     Description = "C# is a general-purpose, multi-paradigm programming language encompassing strong typing, lexically scoped, imperative, declarative, functional, generic, object-oriented (class-based), and component-oriented programming disciplines."
                 },
                 new Skill
                 {
                     Id = 10,
                     Guid = Guid.Parse("99f337c3-175e-44b5-bb6f-c21daef9320c"),
                     Name = ".NET Core",
                     Type = SkillType.Technical,
                     IsEnabled = true,
                     CreationDate = new DateTime(2020, 01, 30),
                     Description = ".NET Core is a free and open-source, managed computer software framework for Windows, Linux, and macOS operating systems. It is a cross-platform successor to .NET Framework."
                 },
                 new Skill
                 {
                     Id = 11,
                     Guid = Guid.Parse("b9d648ef-0199-4813-bb46-3edae60316fa"),
                     Name = "SQL",
                     Type = SkillType.Technical,
                     IsEnabled = true,
                     CreationDate = new DateTime(2020, 01, 30),
                     Description = "SQL stands for Structured Query Language. SQL is used to communicate with a database."
                 },
                 new Skill
                 {
                     Id = 12,
                     Guid = Guid.Parse("6bf0ba43-52eb-42b3-8e7e-e956813d0030"),
                     Name = "Javascript",
                     Type = SkillType.Technical,
                     IsEnabled = true,
                     CreationDate = new DateTime(2020, 01, 30),
                     Description = "Javascript often abbreviated as JS, is a high-level, just-in-time compiled, multi-paradigm programming language that conforms to the ECMAScript specification."
                 },
                 new Skill
                 {
                     Id = 13,
                     Guid = Guid.Parse("f297e677-4614-41a6-8899-244205ef2f61"),
                     Name = "Forward Thinking",
                     Type = SkillType.Soft,
                     IsEnabled = true,
                     CreationDate = new DateTime(2020, 01, 30),
                     Description = "Forward thinking helps you make accurate predictions of the possible needs of your company, as well as outcomes of actions made anywhere in the entire supply chain."
                 },
                 new Skill
                 {
                     Id = 14,
                     Guid = Guid.Parse("53417bc5-a7c1-4bad-8393-78d79b263270"),
                     Name = "Team player",
                     Type = SkillType.Soft,
                     IsEnabled = true,
                     CreationDate = new DateTime(2020, 01, 30),
                     Description = "When it comes to working with other teams or units in the supply chain, it pays to treat everyone with respect and professionalism."
                 }
                 );
        }
    }
}
