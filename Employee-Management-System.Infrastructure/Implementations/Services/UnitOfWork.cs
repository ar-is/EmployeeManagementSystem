using Employee_Management_System.Core.Interfaces.Services;
using Employee_Management_System.Core.Interfaces.Services.Repositories;
using Employee_Management_System.Infrastructure.DbContexts;
using Employee_Management_System.Infrastructure.Implementations.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management_System.Infrastructure.Implementations.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly EMSDbContext _context;

        public IJobRepository Jobs { get; private set; }
        public IJobSkillRepository JobSkills { get; private set; }
        public ISkillRepository Skills { get; private set; }

        public UnitOfWork(EMSDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Jobs = new JobRepository(context);
            JobSkills = new JobSkillRepository(context);
            Skills = new SkillRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    _context.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
