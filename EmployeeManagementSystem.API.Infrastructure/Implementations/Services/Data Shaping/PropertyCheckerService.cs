using EmployeeManagementSystem.API.Core.Interfaces.Services.Data_Shaping;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EmployeeManagementSystem.API.Infrastructure.Implementations.Services.Data_Shaping
{
    public class PropertyCheckerService : IPropertyCheckerService
    {
        public bool TypeHasProperties<T>(string fields)
        {
            if (!string.IsNullOrWhiteSpace(fields))
            {
                var fieldsAfterSplit = fields.Split(',');

                foreach (var field in fieldsAfterSplit)
                {
                    var propertyName = field.Trim();

                    var propertyInfo = typeof(T)
                        .GetProperty(propertyName,
                        BindingFlags.IgnoreCase | 
                        BindingFlags.Public | BindingFlags.Instance);

                    if (propertyInfo == null)
                        return false;
                }
            }

            return true;
        }
    }
}
