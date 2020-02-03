using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.WebClient.Core.Entities
{
    public class ApplicationRole : IdentityRole<int>
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
    }
}
