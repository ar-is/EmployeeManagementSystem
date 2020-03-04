using EmployeeManagementSystem.API.Core.Dtos.EmployeeSkills;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EmployeeManagementSystem.API.Core.Dtos.Employees
{
    public class EmployeeForUpdateDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public ICollection<EmployeeSkillForUpdateDto> EmployeeSkills { get; set; }
            = new Collection<EmployeeSkillForUpdateDto>();
    }
}
