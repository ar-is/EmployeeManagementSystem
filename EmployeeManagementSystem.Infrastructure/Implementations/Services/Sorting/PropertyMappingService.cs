using EmployeeManagementSystem.Core.Dtos.Skills;
using EmployeeManagementSystem.Core.Entities;
using EmployeeManagementSystem.Core.Interfaces.Services.Sorting;
using EmployeeManagementSystem.Utils.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeManagementSystem.Infrastructure.Implementations.Services.Sorting
{
    public class PropertyMappingService : IPropertyMappingService
    {
        private readonly Dictionary<string, PropertyMappingValue> _skillPropertyMapping =
          new Dictionary<string, PropertyMappingValue>(StringComparer.OrdinalIgnoreCase)
          {
               { "Id", new PropertyMappingValue(new List<string>() { "Guid" } ) },
               { "Name", new PropertyMappingValue(new List<string>() { "Name" } ) },
               { "Type", new PropertyMappingValue(new List<string>() { "Type" } ) }
          };

        private readonly IList<IPropertyMapping> _propertyMappings = new List<IPropertyMapping>();

        public PropertyMappingService()
        {
            _propertyMappings.Add(new PropertyMapping<SkillDto, Skill>(_skillPropertyMapping));
        }

        public bool ValidMappingExistsFor<TSource, TDestination>(string fields)
        {
            var propertyMapping = GetPropertyMapping<TSource, TDestination>();

            if (!string.IsNullOrWhiteSpace(fields))
            {
                var fieldsAfterSplit = fields.Split(",");

                foreach (var field in fieldsAfterSplit)
                {
                    if (!propertyMapping.ContainsKey(GetPropertyName(field)))
                        return false;
                }
            }

            return true;
        }

        private string GetPropertyName(string field)
        {
            var trimmedField = field.Trim();
            var indexOfFirstSpace = trimmedField.IndexOf(" ");

            return indexOfFirstSpace == -1 ?
                trimmedField : trimmedField.Remove(indexOfFirstSpace);
        }

        public Dictionary<string, PropertyMappingValue> GetPropertyMapping
            <TSource, TDestination>()
        {
            var matchingMapping = _propertyMappings
                .OfType<PropertyMapping<TSource, TDestination>>();

            if (matchingMapping.Count() != 1)
            {
                throw new Exception($"Cannot find exact property mapping instance " +
                $"for <{typeof(TSource)},{typeof(TDestination)}");
            }

            return matchingMapping.First().MappingDictionary;
        }
    }
}
