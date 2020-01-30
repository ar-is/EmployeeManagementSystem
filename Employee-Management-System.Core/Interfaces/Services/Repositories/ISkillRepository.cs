using Employee_Management_System.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management_System.Core.Interfaces.Services.Repositories
{
    public interface ISkillRepository
    {
        IEnumerable<Skill> GetSkills(Guid jobId);
    }
}
