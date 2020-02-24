using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EmployeeManagementSystem.API.Core.Dtos.Skills
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTimeOffset HiringDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string LatestSkillsetUpdate { get; set; }
        public string LatestUpdate { get; set; }

        public string Job { get; set; }

        public ICollection<SkillDto> Skills { get; set; }
            = new Collection<SkillDto>();
    }
}
