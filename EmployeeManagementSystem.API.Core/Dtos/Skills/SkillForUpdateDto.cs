using EmployeeManagementSystem.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.API.Core.Dtos.Skills
{
    public class SkillForUpdateDto
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }
    }
}
