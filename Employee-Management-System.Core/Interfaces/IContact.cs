using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management_System.Core.Interfaces
{
    public interface IContact
    {
        public string PhoneNumber { get; }
        public string Email { get; }
    }
}
