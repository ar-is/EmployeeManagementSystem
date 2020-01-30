using Employee_Management_System.Core.Interfaces.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management_System.Core.Interfaces.Services
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
