using EmployeeManagementSystem.API.Core.Interfaces.Services.Repositories;
using EmployeeManagementSystem.API.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeManagementSystem.API.Infrastructure.Implementations.Services.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly EMSDbContext _context;

        public JobRepository(EMSDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool JobExists(Guid jobId)
        {
            if (jobId == Guid.Empty)
                throw new ArgumentNullException(nameof(jobId));

            return _context.Jobs.Any(j => j.Guid == jobId);
        }
    }
}
