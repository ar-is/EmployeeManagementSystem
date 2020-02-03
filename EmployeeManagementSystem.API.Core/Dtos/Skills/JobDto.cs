using EmployeeManagementSystem.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.API.Core.Dtos.Skills
{
    public class JobDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public JobSeniorityLevel SeniorityLevel { get; set; }
        public string Description { get; set; }
    }
}
