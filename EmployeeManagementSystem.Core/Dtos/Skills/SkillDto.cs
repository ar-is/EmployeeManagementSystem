using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.Core.Dtos.Skills
{
    public class SkillDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string CreationDate { get; set; }
    }
}
