using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management_System.Core.Entities
{
    public class JobSkill
    {
        public short SkillId { get; set; }
        public Skill Skill { get; set; }

        public short JobId { get; set; }
        public Job Job { get; set; }
    }
}
