using Employee_Management_System.Core.Entities;
using Employee_Management_System.Infrastructure.EntityConfigurations;
using Employee_Management_System.Infrastructure.Helpers.Extension_Methods;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Employee_Management_System.Infrastructure.DbContexts
{
    public class EMSDbContext : DbContext
    {
        public EMSDbContext(DbContextOptions<EMSDbContext> options) : base(options)
        { }

        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.RemovePluralizingTableNameConvention();

            builder.ApplyConfiguration(new JobConfiguration());
            builder.ApplyConfiguration(new SkillConfiguration());
            builder.ApplyConfiguration(new JobSkillConfiguration());
        }
    }
}
