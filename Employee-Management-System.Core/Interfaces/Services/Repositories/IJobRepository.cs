using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management_System.Core.Interfaces.Services.Repositories
{
    public interface IJobRepository
    {
        bool JobExists(Guid jobId);
    }
}
