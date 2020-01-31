using EmployeeManagementSystem.Core.Entities;
using EmployeeManagementSystem.Core.Interfaces.Services.Repositories;
using EmployeeManagementSystem.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeManagementSystem.Infrastructure.Implementations.Services.Repositories
{
    public class JobSkillRepository : IJobSkillRepository
    {
        private readonly EMSDbContext _context;

        public JobSkillRepository(EMSDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<JobSkill> GetJobSkills(Guid jobId)
        {
            if (jobId == Guid.Empty)
                throw new ArgumentNullException(nameof(jobId));

            var job = _context.Jobs.FirstOrDefault(j => j.Guid == jobId);

            return _context.JobSkills
                .Include(js => js.Skill)
                .Include(js => js.Job)
                .Where(js => js.JobId == job.Id)
                .ToList();
        }
    }
}
