using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.Utils.ResourceFilters.Skills
{
    public class SkillsFilter
    {
        [FromQuery(Name = "name")]
        public string Name { get; set; }

        [FromQuery(Name = "type")]
        public string Type { get; set; }

        public bool HasName()
        {
            if (!string.IsNullOrEmpty(Name) && string.IsNullOrWhiteSpace(Type))
            {
                Name = Name.Trim();
                return true;
            }

            return false;
        }

        public bool HasType()
        {
            if (!string.IsNullOrEmpty(Type) && string.IsNullOrWhiteSpace(Name))
                return true;

            return false;
        }

        public bool HasNameAndType()
        {
            if (!string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Type))
            {
                Name = Name.Trim();
                Type = Type.Trim();
                return true;
            }

            return false;
        }
    }
}
