using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.Utils.ResourceFilters.Skills
{
    public class SkillsResourceParameters : ResourceParameters
    {
        [FromQuery(Name = "")]
        public SkillsFilter Filter { get; set; }

        public override string OrderBy { get; set; } = "Name";
    }
}
