using EmployeeManagementSystem.Utils.Paging;
using EmployeeManagementSystem.Utils.ResourceFilters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.Core.Interfaces.Services.Data_Shaping
{
    public interface IDataShapingService<T> where T : class
    {
        object GetShapedCollection(PagedList<T> collection, 
            ResourceParameters resourceParameters, MediaTypeHeaderValue parsedMediaType);

        IDictionary<string, object> GetShapedEntity(MediaTypeHeaderValue parsedMediaType,
            T entity, string fields);
    }
}
