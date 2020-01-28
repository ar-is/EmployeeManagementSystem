using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management_System.API.Core.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime HiringDate { get; set; }

        public DateTime LatestSkillsetUpdate { get; set; }
        public DateTime LatestUpdate { get; set; }

        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }
}
