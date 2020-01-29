using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management_System.Core.Entities
{
    public class Job
    {
        public short Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();

        public string Title { get; set; }
        public JobSeniorityLevel SeniorityLevel { get; set; }
        public string Description { get; set; }

        public ICollection<JobSkill> JobSkills { get; set; }
    }
}
