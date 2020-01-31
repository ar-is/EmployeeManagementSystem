using EmployeeManagementSystem.API.Core.Entities;
using EmployeeManagementSystem.API.Infrastructure.EntityConfigurations;
using EmployeeManagementSystem.API.Infrastructure.Helpers.Extension_Methods;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementSystem.API.Infrastructure.DbContexts
{
    public class EMSDbContext : DbContext
    {
        public EMSDbContext(DbContextOptions<EMSDbContext> options) : base(options)
        { }
        
        public DbSet<Department> Departments { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<JobSkill> JobSkills { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.RemovePluralizingTableNameConvention();

            builder.ApplyConfiguration(new DepartmentConfiguration());
            builder.ApplyConfiguration(new JobConfiguration());
            builder.ApplyConfiguration(new SkillConfiguration());
            builder.ApplyConfiguration(new JobSkillConfiguration());
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new EmployeeSkillConfiguration());
        }
    }
}
