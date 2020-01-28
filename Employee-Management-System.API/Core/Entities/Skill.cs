using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management_System.API.Core.Entities
{
    public class Skill
    {
        public short Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();

        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
    }
}
