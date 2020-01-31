using EmployeeManagementSystem.Core.Entities;
using EmployeeManagementSystem.Utils.Paging;
using EmployeeManagementSystem.Utils.ResourceFilters.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.Core.Interfaces.Services.Repositories
{
    public interface ISkillRepository
    {
        //IEnumerable<Skill> GetSkills(Guid jobId);
        PagedList<Skill> GetSkills(Guid jobId, SkillsResourceParameters parameters);
    }
}
