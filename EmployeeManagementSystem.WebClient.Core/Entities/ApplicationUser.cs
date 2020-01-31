using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.WebClient.Core.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public Guid Guid { get; private set; } = Guid.NewGuid();
    }
}
