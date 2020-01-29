using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management_System.Core.Entities
{
    public class Skill
    {
        public short Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();

        public string Name { get; set; }
        public SkillType Type { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        
        public ICollection<JobSkill> JobSkills { get; set; }

        public Skill()
        {}

        public Skill(SkillType type, string name, string description)
        {
            Type = type;
            Name = name;
            Description = description;
        }

        public static Skill CreateTechnicalSkill(string name, string description)
        {
            return new Skill(SkillType.Technical, name, description);
        }

        public static Skill CreateSoftSkill(string name, string description)
        {
            return new Skill(SkillType.Soft, name, description);
        }
    }
}
