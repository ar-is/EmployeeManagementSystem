using EmployeeManagementSystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EmployeeManagementSystem.Core.Entities
{
    public class Employee : IContact
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTimeOffset HiringDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public DateTimeOffset LatestSkillsetUpdate { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset LatestUpdate { get; set; } = DateTimeOffset.UtcNow;

        public short JobId { get; set; }
        public Job Job { get; set; }

        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
            = new Collection<EmployeeSkill>();
    }
}
