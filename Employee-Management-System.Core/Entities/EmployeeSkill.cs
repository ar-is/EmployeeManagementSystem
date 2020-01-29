using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management_System.Core.Entities
{
    public class EmployeeSkill
    {
        public short SkillId { get; set; }
        public Skill Skill { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
