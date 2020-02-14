using EmployeeManagementSystem.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.API.Core.Dtos.Skills
{
    public class SkillFullDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public SkillType Type { get; set; }

        public string Description { get; set; }

        public DateTimeOffset CreationDate { get; set; }

        public bool IsEnabled { get; set; }
    }
}
