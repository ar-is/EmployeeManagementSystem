using EmployeeManagementSystem.API.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.API.Infrastructure.EntityConfigurations
{
    public class JobSkillConfiguration : IEntityTypeConfiguration<JobSkill>
    {
        public void Configure(EntityTypeBuilder<JobSkill> builder)
        {
            ConfigureKeysAndIndexes(builder);
            ConfigureEntityRelationships(builder);
            SeedData(builder);
        }

        private void ConfigureKeysAndIndexes(EntityTypeBuilder<JobSkill> builder)
        {
            builder.HasKey(js => new { js.SkillId, js.JobId });
        }

        private void ConfigureEntityRelationships(EntityTypeBuilder<JobSkill> builder)
        {
            builder
                .HasOne(js => js.Job)
                .WithMany(j => j.JobSkills)
                .HasForeignKey(js => js.JobId);

            builder
                .HasOne(js => js.Skill)
                .WithMany(s => s.JobSkills)
                .HasForeignKey(js => js.SkillId);
        }

        private void SeedData(EntityTypeBuilder<JobSkill> builder)
        {
            builder.HasData(
                new JobSkill { JobId = 1, SkillId = 1 },
                new JobSkill { JobId = 1, SkillId = 2 },
                new JobSkill { JobId = 1, SkillId = 5 },
                new JobSkill { JobId = 1, SkillId = 13 },
                new JobSkill { JobId = 1, SkillId = 14 },
                new JobSkill { JobId = 2, SkillId = 1 },
                new JobSkill { JobId = 2, SkillId = 2 },
                new JobSkill { JobId = 2, SkillId = 5 },
                new JobSkill { JobId = 3, SkillId = 1 },
                new JobSkill { JobId = 3, SkillId = 2 },
                new JobSkill { JobId = 3, SkillId = 4 },
                new JobSkill { JobId = 3, SkillId = 6 },
                new JobSkill { JobId = 3, SkillId = 7 },
                new JobSkill { JobId = 3, SkillId = 8 },
                new JobSkill { JobId = 3, SkillId = 9 },
                new JobSkill { JobId = 3, SkillId = 14 },
                new JobSkill { JobId = 4, SkillId = 1 },
                new JobSkill { JobId = 4, SkillId = 2 },
                new JobSkill { JobId = 4, SkillId = 6 },
                new JobSkill { JobId = 4, SkillId = 7 },
                new JobSkill { JobId = 4, SkillId = 8 },
                new JobSkill { JobId = 4, SkillId = 9 },
                new JobSkill { JobId = 4, SkillId = 10 },
                new JobSkill { JobId = 4, SkillId = 11 },
                new JobSkill { JobId = 4, SkillId = 12 },
                new JobSkill { JobId = 4, SkillId = 13 },
                new JobSkill { JobId = 5, SkillId = 1 },
                new JobSkill { JobId = 5, SkillId = 2 },
                new JobSkill { JobId = 5, SkillId = 4 },
                new JobSkill { JobId = 5, SkillId = 5 },
                new JobSkill { JobId = 5, SkillId = 8 },
                new JobSkill { JobId = 5, SkillId = 11 },
                new JobSkill { JobId = 5, SkillId = 13 },
                new JobSkill { JobId = 5, SkillId = 14 },
                new JobSkill { JobId = 6, SkillId = 1 },
                new JobSkill { JobId = 6, SkillId = 4 },
                new JobSkill { JobId = 6, SkillId = 5 },
                new JobSkill { JobId = 6, SkillId = 13 },
                new JobSkill { JobId = 6, SkillId = 14 },
                new JobSkill { JobId = 7, SkillId = 1 },
                new JobSkill { JobId = 7, SkillId = 2 },
                new JobSkill { JobId = 7, SkillId = 3 },
                new JobSkill { JobId = 7, SkillId = 13 }
                );
        }
    }
}
