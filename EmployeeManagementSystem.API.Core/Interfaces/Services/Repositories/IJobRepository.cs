using EmployeeManagementSystem.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.API.Core.Interfaces.Services.Repositories
{
    public interface IJobRepository
    {
        bool JobExists(Guid jobId);
        IEnumerable<Job> GetJobs();
        Job GetFirstJob();
    }
}
