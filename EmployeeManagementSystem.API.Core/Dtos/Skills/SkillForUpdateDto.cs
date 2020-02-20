﻿using EmployeeManagementSystem.API.Core.Dtos.JobSkills;
using EmployeeManagementSystem.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EmployeeManagementSystem.API.Core.Dtos.Skills
{
    public class SkillForUpdateDto
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public bool IsEnabled { get; set; }

        public ICollection<JobSkillForUpdateDto> JobSkills { get; set; }
            = new Collection<JobSkillForUpdateDto>();
    }
}
