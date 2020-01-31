using EmployeeManagementSystem.Core.Dtos.Links;
using EmployeeManagementSystem.Core.Interfaces.Services.Pagination;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.Infrastructure.Implementations.Services.Pagination
{
    public class RootPaginationService : IRootPaginationService
    {
        private readonly IUrlHelper _urlHelper;

        public RootPaginationService(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper ?? throw new ArgumentNullException(nameof(urlHelper));
        }

        public IEnumerable<LinkDto> CreateRootLinks()
        {
            return new List<LinkDto>
            {
                new LinkDto(_urlHelper.Link("GetRoot", new { }),
                    "self",
                    "GET"),

                new LinkDto(_urlHelper.Link("GetSkills", new { }),
                    "skills",
                    "GET"),

                new LinkDto(_urlHelper.Link("GetSkillsForJob", new { }),
                    "skills_for_job",
                    "GET"),

                new LinkDto(_urlHelper.Link("CreateSkill", new { }),
                    "create_skill",
                    "POST")
            };
        }
    }
}
