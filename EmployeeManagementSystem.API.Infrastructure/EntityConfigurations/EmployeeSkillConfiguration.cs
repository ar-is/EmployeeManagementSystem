using EmployeeManagementSystem.API.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.API.Infrastructure.EntityConfigurations
{
    public class EmployeeSkillConfiguration : IEntityTypeConfiguration<EmployeeSkill>
    {
        public void Configure(EntityTypeBuilder<EmployeeSkill> builder)
        {
            ConfigureKeysAndIndexes(builder);
            ConfigureEntityRelationships(builder);
            SeedData(builder);
        }

        private void ConfigureKeysAndIndexes(EntityTypeBuilder<EmployeeSkill> builder)
        {
            builder.HasKey(es => new { es.SkillId, es.EmployeeId });
        }

        private void ConfigureEntityRelationships(EntityTypeBuilder<EmployeeSkill> builder)
        {
            builder
                .HasOne(es => es.Employee)
                .WithMany(e => e.EmployeeSkills)
                .HasForeignKey(es => es.EmployeeId);

            builder
                .HasOne(es => es.Skill)
                .WithMany(s => s.EmployeeSkills)
                .HasForeignKey(es => es.SkillId);
        }

        private void SeedData(EntityTypeBuilder<EmployeeSkill> builder)
        {
            builder.HasData(
                new EmployeeSkill { EmployeeId = 1, SkillId = 1 },
                new EmployeeSkill { EmployeeId = 1, SkillId = 2 },
                new EmployeeSkill { EmployeeId = 1, SkillId = 4 },
                new EmployeeSkill { EmployeeId = 1, SkillId = 6 },
                new EmployeeSkill { EmployeeId = 1, SkillId = 7 },
                new EmployeeSkill { EmployeeId = 1, SkillId = 8 },
                new EmployeeSkill { EmployeeId = 1, SkillId = 9 },
                new EmployeeSkill { EmployeeId = 1, SkillId = 12 },
                new EmployeeSkill { EmployeeId = 1, SkillId = 14 },
                new EmployeeSkill { EmployeeId = 2, SkillId = 1 },
                new EmployeeSkill { EmployeeId = 2, SkillId = 2 },
                new EmployeeSkill { EmployeeId = 2, SkillId = 4 },
                new EmployeeSkill { EmployeeId = 2, SkillId = 5 },
                new EmployeeSkill { EmployeeId = 2, SkillId = 6 },
                new EmployeeSkill { EmployeeId = 2, SkillId = 7 },
                new EmployeeSkill { EmployeeId = 2, SkillId = 8 },
                new EmployeeSkill { EmployeeId = 2, SkillId = 9 },
                new EmployeeSkill { EmployeeId = 2, SkillId = 10 },
                new EmployeeSkill { EmployeeId = 2, SkillId = 11 },
                new EmployeeSkill { EmployeeId = 2, SkillId = 12 },
                new EmployeeSkill { EmployeeId = 2, SkillId = 13 },
                new EmployeeSkill { EmployeeId = 2, SkillId = 14 },
                new EmployeeSkill { EmployeeId = 3, SkillId = 1 },
                new EmployeeSkill { EmployeeId = 3, SkillId = 2 },
                new EmployeeSkill { EmployeeId = 3, SkillId = 3 },
                new EmployeeSkill { EmployeeId = 3, SkillId = 5 },
                new EmployeeSkill { EmployeeId = 3, SkillId = 13 },               
                new EmployeeSkill { EmployeeId = 4, SkillId = 1 },
                new EmployeeSkill { EmployeeId = 4, SkillId = 2 },
                new EmployeeSkill { EmployeeId = 4, SkillId = 6 },
                new EmployeeSkill { EmployeeId = 4, SkillId = 7 },
                new EmployeeSkill { EmployeeId = 4, SkillId = 8 },
                new EmployeeSkill { EmployeeId = 4, SkillId = 9 },
                new EmployeeSkill { EmployeeId = 4, SkillId = 10 },
                new EmployeeSkill { EmployeeId = 4, SkillId = 11 },
                new EmployeeSkill { EmployeeId = 4, SkillId = 12 },
                new EmployeeSkill { EmployeeId = 4, SkillId = 13 },
                new EmployeeSkill { EmployeeId = 5, SkillId = 1 },
                new EmployeeSkill { EmployeeId = 5, SkillId = 4 },
                new EmployeeSkill { EmployeeId = 5, SkillId = 5 },
                new EmployeeSkill { EmployeeId = 5, SkillId = 13 },
                new EmployeeSkill { EmployeeId = 5, SkillId = 14 },
                new EmployeeSkill { EmployeeId = 6, SkillId = 1 },
                new EmployeeSkill { EmployeeId = 6, SkillId = 2 },
                new EmployeeSkill { EmployeeId = 6, SkillId = 4 },
                new EmployeeSkill { EmployeeId = 6, SkillId = 6 },
                new EmployeeSkill { EmployeeId = 6, SkillId = 7 },
                new EmployeeSkill { EmployeeId = 6, SkillId = 8 },
                new EmployeeSkill { EmployeeId = 6, SkillId = 9 },
                new EmployeeSkill { EmployeeId = 6, SkillId = 14 },
                new EmployeeSkill { EmployeeId = 7, SkillId = 1 },
                new EmployeeSkill { EmployeeId = 7, SkillId = 2 },
                new EmployeeSkill { EmployeeId = 7, SkillId = 4 },
                new EmployeeSkill { EmployeeId = 7, SkillId = 6 },
                new EmployeeSkill { EmployeeId = 7, SkillId = 7 },
                new EmployeeSkill { EmployeeId = 7, SkillId = 8 },
                new EmployeeSkill { EmployeeId = 7, SkillId = 9 },
                new EmployeeSkill { EmployeeId = 7, SkillId = 14 },
                new EmployeeSkill { EmployeeId = 8, SkillId = 1 },
                new EmployeeSkill { EmployeeId = 8, SkillId = 2 },
                new EmployeeSkill { EmployeeId = 8, SkillId = 4 },
                new EmployeeSkill { EmployeeId = 8, SkillId = 5 },
                new EmployeeSkill { EmployeeId = 8, SkillId = 13 },
                new EmployeeSkill { EmployeeId = 8, SkillId = 14 }
                );
        }
    }
}
