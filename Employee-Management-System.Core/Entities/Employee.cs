using Employee_Management_System.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public DateTime LatestSkillsetUpdate { get; set; } = DateTime.Now;
        public DateTime LatestUpdate { get; set; } = DateTime.Now;

        public short JobId { get; set; }
        public Job Job { get; set; }

        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
            = new Collection<EmployeeSkill>();
    }
}
