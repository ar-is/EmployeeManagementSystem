using Employee_Management_System.Core.Interfaces.Services.Repositories;
using Employee_Management_System.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Employee_Management_System.Infrastructure.Implementations.Services.Repositories
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
