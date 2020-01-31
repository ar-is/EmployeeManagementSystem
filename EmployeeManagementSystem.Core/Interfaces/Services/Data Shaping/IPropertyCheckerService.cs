using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.Core.Interfaces.Services.Data_Shaping
{
    public interface IPropertyCheckerService
    {
        bool TypeHasProperties<T>(string fields);
    }
}
