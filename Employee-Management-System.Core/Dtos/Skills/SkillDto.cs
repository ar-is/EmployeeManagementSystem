using Employee_Management_System.Core.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management_System.Core.Dtos.Skills
{
    public class SkillDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public SkillType Type { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
