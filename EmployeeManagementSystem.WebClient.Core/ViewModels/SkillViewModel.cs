using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.WebClient.Core.ViewModels
{
    public class SkillViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string CreationDate { get; set; }

        public bool IsEnabled { get; set; }

        public IEnumerable<JobViewModel> Jobs { get; set; }

        public string NamePlacehodler => "Enter Skill Name";
        public string DescriptionPlaceholder => "Enter Skill Description";
    }
}
