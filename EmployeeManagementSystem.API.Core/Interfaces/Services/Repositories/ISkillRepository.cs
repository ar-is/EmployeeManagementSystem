using EmployeeManagementSystem.API.Core.Entities;
using EmployeeManagementSystem.API.Utils.Paging;
using EmployeeManagementSystem.API.Utils.ResourceFilters.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.API.Core.Interfaces.Services.Repositories
{
    public interface ISkillRepository
    {
        //IEnumerable<Skill> GetSkills(Guid jobId);
        PagedList<Skill> GetSkills(Guid jobId, SkillsResourceParameters parameters);
        Skill GetSkill(Guid skillId);
    }
}
