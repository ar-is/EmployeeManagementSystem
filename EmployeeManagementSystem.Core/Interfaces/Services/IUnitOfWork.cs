using EmployeeManagementSystem.Core.Interfaces.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.Core.Interfaces.Services
{
    public interface IUnitOfWork
    {
        IJobRepository Jobs { get; }
        IJobSkillRepository JobSkills { get; }
        ISkillRepository Skills { get; }

        void Complete();
        void Dispose();
    }
}
