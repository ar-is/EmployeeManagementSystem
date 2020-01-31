using EmployeeManagementSystem.Core.Dtos.Links;
using EmployeeManagementSystem.Utils.Paging;
using EmployeeManagementSystem.Utils.ResourceFilters;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.Core.Interfaces.Services.Pagination
{
    public interface IPaginationService<T> where T : class
    {
        IEnumerable<LinkDto> CreateLinksForEntity(Guid entityId, string fields);
        string CreateResourceUri(ResourceParameters resourceParameters, ResourceUriType type);

        IEnumerable<LinkDto> CreateLinksForEntities(ResourceParameters resourceParameters,
            bool hasNext, bool hasPrevious)
        {
            var links = new List<LinkDto>
            {
                new LinkDto(CreateResourceUri(
                    resourceParameters, ResourceUriType.Current),
                    "currentPage",
                    "GET")
            };

            if (hasNext)
            {
                links.Add(
                new LinkDto(CreateResourceUri(
                    resourceParameters, ResourceUriType.NextPage),
                    "nextPage",
                    "GET"));
            }

            if (hasPrevious)
            {
                links.Add(
                new LinkDto(CreateResourceUri(
                    resourceParameters, ResourceUriType.PreviousPage),
                    "previousPage",
                    "GET"));
            }

            return links;
        }

        bool IncludeLinks(MediaTypeHeaderValue parsedMediaType)
        {
            return parsedMediaType.SubTypeWithoutSuffix
                .EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
        }

        StringSegment GetPrimaryMediaType(MediaTypeHeaderValue parsedMediaType)
        {
            return IncludeLinks(parsedMediaType) ?
                parsedMediaType.SubTypeWithoutSuffix
                .Substring(0, parsedMediaType.SubTypeWithoutSuffix.Length - 8)
                : parsedMediaType.SubTypeWithoutSuffix;
        }
     
        object CreatePaginationMetadata(PagedList<T> collection, ResourceParameters parameters)
        {
            return new
            {
                totalCount = collection.TotalCount,
                pageSize = collection.PageSize,
                currentPage = collection.CurrentPage,
                totalPages = collection.TotalPages
            };
        }
    }
}
