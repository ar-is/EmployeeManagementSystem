using EmployeeManagementSystem.Utils.Sorting;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.Core.Interfaces.Services.Sorting
{
    public interface IPropertyMappingService
    {
        bool ValidMappingExistsFor<TSource, TDestination>(string fields);
        Dictionary<string, PropertyMappingValue> GetPropertyMapping<TSource, TDestination>();
    }
}
