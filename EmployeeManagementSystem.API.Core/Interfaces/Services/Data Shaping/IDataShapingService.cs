using EmployeeManagementSystem.API.Utils.Paging;
using EmployeeManagementSystem.API.Utils.ResourceFilters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.API.Core.Interfaces.Services.Data_Shaping
{
    public interface IDataShapingService<T> where T : class
    {
        object GetShapedCollection(PagedList<T> collection, 
            ResourceParameters resourceParameters, MediaTypeHeaderValue parsedMediaType);

        IDictionary<string, object> GetShapedEntity(MediaTypeHeaderValue parsedMediaType,
            T entity, string fields);
    }
}
