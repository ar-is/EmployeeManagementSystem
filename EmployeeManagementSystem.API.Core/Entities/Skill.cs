using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EmployeeManagementSystem.API.Core.Entities
{
    public class Skill
    {
        public short Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();

        public string Name { get; set; }
        public SkillType Type { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreationDate { get; set; } = DateTimeOffset.UtcNow;
        
        public ICollection<JobSkill> JobSkills { get; set; }
            = new Collection<JobSkill>();

        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
            = new Collection<EmployeeSkill>();

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
