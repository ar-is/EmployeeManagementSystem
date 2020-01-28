using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management_System.API.Core.Entities
{
    public class Department
    {
        public short Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();

        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public int ManagerId { get; set; }
        public Employee Manager { get; set; }
    }
}
