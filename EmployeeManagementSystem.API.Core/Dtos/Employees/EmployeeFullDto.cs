using EmployeeManagementSystem.API.Core.Dtos.Jobs;
using EmployeeManagementSystem.API.Core.Dtos.Skills;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EmployeeManagementSystem.API.Core.Dtos.Employees
{
    public class EmployeeFullDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTimeOffset HiringDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public DateTimeOffset LatestSkillsetUpdate { get; set; }
        public DateTimeOffset LatestUpdate { get; set; }

        public JobDto Job { get; set; }

        public ICollection<SkillDto> Skills { get; set; }
            = new Collection<SkillDto>();
    }
}
