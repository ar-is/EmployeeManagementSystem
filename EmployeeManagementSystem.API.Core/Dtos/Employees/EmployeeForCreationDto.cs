using EmployeeManagementSystem.API.Core.Dtos.EmployeeSkills;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EmployeeManagementSystem.API.Core.Dtos.Employees
{
    public class EmployeeForCreationDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTimeOffset HiringDate { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public Guid JobId { get; set; }

        public ICollection<EmployeeSkillForCreationDto> EmployeeSkills { get; set; }
            = new Collection<EmployeeSkillForCreationDto>();
    }
}
