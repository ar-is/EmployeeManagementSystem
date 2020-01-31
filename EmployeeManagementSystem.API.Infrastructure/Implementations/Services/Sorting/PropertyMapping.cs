using EmployeeManagementSystem.API.Core.Interfaces.Services.Sorting;
using EmployeeManagementSystem.API.Utils.Sorting;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.API.Infrastructure.Implementations.Services.Sorting
{
    public class PropertyMapping<TSource, TDestination> : IPropertyMapping
    {
        public Dictionary<string, PropertyMappingValue> MappingDictionary { get; private set; }

        public PropertyMapping(Dictionary<string, PropertyMappingValue> mappingDictionary)
        {
            MappingDictionary = mappingDictionary ??
                throw new ArgumentNullException(nameof(mappingDictionary));
        }
    }
}
