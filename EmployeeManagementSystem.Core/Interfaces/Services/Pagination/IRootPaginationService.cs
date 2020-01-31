using EmployeeManagementSystem.Core.Dtos.Links;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.Core.Interfaces.Services.Pagination
{
    public interface IRootPaginationService
    {
        IEnumerable<LinkDto> CreateRootLinks();
    }
}
