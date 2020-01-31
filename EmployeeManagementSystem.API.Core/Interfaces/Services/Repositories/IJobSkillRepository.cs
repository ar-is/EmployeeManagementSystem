using EmployeeManagementSystem.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.API.Core.Interfaces.Services.Repositories
{
    public interface IJobSkillRepository
    {
        IEnumerable<JobSkill> GetJobSkills(Guid jobId);
    }
}
