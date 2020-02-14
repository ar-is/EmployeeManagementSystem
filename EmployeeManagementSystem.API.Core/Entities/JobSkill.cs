using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.API.Core.Entities
{
    public class JobSkill
    {
        public short SkillId { get; set; }
        public Skill Skill { get; set; }

        public short JobId { get; set; }
        public Job Job { get; set; }

        public bool IsEnabled { get; set; }
    }
}
