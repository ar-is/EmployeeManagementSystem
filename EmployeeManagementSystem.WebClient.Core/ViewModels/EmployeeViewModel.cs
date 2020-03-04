using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EmployeeManagementSystem.WebClient.Core.ViewModels
{
    public class EmployeeViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTimeOffset HiringDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public DateTimeOffset LatestSkillsetUpdate { get; set; }
        public DateTimeOffset LatestUpdate { get; set; }

        public JobViewModel Job { get; set; }

        public ICollection<SkillViewModel> Skills { get; set; }
            = new Collection<SkillViewModel>();

        public ICollection<SkillViewModel> AllSkills { get; set; }
            = new Collection<SkillViewModel>();

        public string FullName => $"{Name} {Surname}";
    }
}
