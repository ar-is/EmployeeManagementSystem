using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.Core.Interfaces.Services.Repositories
{
    public interface IJobRepository
    {
        bool JobExists(Guid jobId);
    }
}
