using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EmployeeManagementSystem.API.Core.Dtos.Skills
{
    public class SkillDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string CreationDate { get; set; }

        public bool IsEnabled { get; set; }

        public ICollection<JobDto> Jobs { get; set; }
            = new Collection<JobDto>();
    }
}
