using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EmployeeManagementSystem.API.Core.Entities
{
    public class Job
    {
        public short Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();

        public string Title { get; set; }
        public JobSeniorityLevel SeniorityLevel { get; set; }
        public string Description { get; set; }

        public short DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<JobSkill> JobSkills { get; set; }
            = new Collection<JobSkill>();

        public ICollection<Employee> Employees { get; set; }
            = new Collection<Employee>();
    }
}
