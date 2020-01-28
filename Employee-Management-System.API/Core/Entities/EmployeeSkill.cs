using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management_System.API.Core.Entities
{
    public class EmployeeSkill
    {
        public short SkillId { get; set; }
        public Skill Skill { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
