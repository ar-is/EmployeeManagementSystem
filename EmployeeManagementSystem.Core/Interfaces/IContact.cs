using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.Core.Interfaces
{
    public interface IContact
    {
        public string PhoneNumber { get; }
        public string Email { get; }
    }
}
