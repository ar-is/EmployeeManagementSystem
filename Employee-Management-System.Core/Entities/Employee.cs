using Employee_Management_System.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management_System.Core.Entities
{
    public class Employee : IContact
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime HiringDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public DateTime LatestSkillsetUpdate { get; set; }
        public DateTime LatestUpdate { get; set; }

        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }      
    }
}
