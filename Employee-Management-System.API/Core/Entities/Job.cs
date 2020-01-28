using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management_System.API.Core.Entities
{
    public class Job
    {
        public short Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
