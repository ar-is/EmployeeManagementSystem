using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.API.Utils.VendorMediaTypes
{
    public class SkillMediaTypes : MediaTypes
    {
        public const string PrimaryFullSkill = "vnd.marvin.skill.full";
        public const string FullSkillJson = "application/vnd.marvin.skill.full+json";
        public const string FullSkillHateoasPlusJson = "application/vnd.marvin.skill.full.hateoas+json";
        public const string FriendlySkillJson = "application/vnd.marvin.skill.friendly+json";
        public const string FriendlySkillHateoasPlusJson = "application/vnd.marvin.skill.friendly.hateoas+json";
    }
}
