using EmployeeManagementSystem.Core.Dtos.Links;
using EmployeeManagementSystem.Core.Entities;
using EmployeeManagementSystem.Core.Interfaces.Services.Pagination;
using EmployeeManagementSystem.Utils.Paging;
using EmployeeManagementSystem.Utils.ResourceFilters;
using EmployeeManagementSystem.Utils.ResourceFilters.Skills;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.Infrastructure.Implementations.Services.Pagination
{
    public class SkillPaginationService : IPaginationService<Skill>, IDependentEntityPaginationService<Skill>
    {
        private readonly IUrlHelper _urlHelper;

        public SkillPaginationService(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper ?? throw new ArgumentNullException(nameof(urlHelper));
        }

        public string CreateResourceUri(ResourceParameters resourceParameters,
           ResourceUriType type)
        {
            var skillsResourceParameters = (SkillsResourceParameters)resourceParameters;

            string fields = skillsResourceParameters.Fields,
                   orderBy = skillsResourceParameters.OrderBy,
                   name = skillsResourceParameters.Filter == null ?
                "" : skillsResourceParameters.Filter.Name,
                   skillType = skillsResourceParameters.Filter == null ?
                "" : skillsResourceParameters.Filter.Type;
            int pageNumber = skillsResourceParameters.PageNumber,
                pageSize = skillsResourceParameters.PageSize;

            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return _urlHelper.Link("GetSkillsForJob",
                      new
                      {
                          fields,
                          orderBy,
                          pageNumber = pageNumber - 1,
                          pageSize,
                          name,
                          skillType
                      });
                case ResourceUriType.NextPage:
                    return _urlHelper.Link("GetSkillsForJob",
                      new
                      {
                          fields,
                          orderBy,
                          pageNumber = pageNumber + 1,
                          pageSize,
                          name,
                          skillType
                      });
                case ResourceUriType.Current:
                default:
                    return _urlHelper.Link("GetSkillsForJob",
                    new
                    {
                        fields,
                        orderBy,
                        pageNumber,
                        pageSize,
                        name,
                        skillType
                    });
            }
        }

        public IEnumerable<LinkDto> CreateLinksForEntity(Guid skillId, string fields)
        {
            var links = new List<LinkDto>();

            if (string.IsNullOrWhiteSpace(fields))
            {
                links.Add(
                  new LinkDto(_urlHelper.Link("GetSkill", new { skillId }),
                  "get_skill",
                  "GET"));
            }
            else
            {
                links.Add(
                  new LinkDto(_urlHelper.Link("GetSkill", new { skillId, fields }),
                  "get_skill",
                  "GET"));
            }

            links.Add(
                new LinkDto(_urlHelper.Link("DeleteSkill", new { skillId }),
                "delete_skill",
                "DELETE"));

            return links;
        }

        public IEnumerable<LinkDto> CreateLinksForDependentEntity(Guid jobId, Guid skillId, 
            string fields)
        {
            var links = new List<LinkDto>();

            if (string.IsNullOrWhiteSpace(fields))
            {
                links.Add(
                  new LinkDto(_urlHelper.Link("GetSkill", new { skillId }),
                  "get_skill",
                  "GET"));

                links.Add(
                  new LinkDto(_urlHelper.Link("GetSkillForJob", new { jobId, skillId }),
                  "get_skill_for_job",
                  "GET"));
            }
            else
            {
                links.Add(
                  new LinkDto(_urlHelper.Link("GetSkill", new { skillId, fields }),
                  "get_skill",
                  "GET"));
            }

            links.Add(
                new LinkDto(_urlHelper.Link("UpdateSkill", new { jobId, skillId }),
                "update_skill",
                "PUT"));

            links.Add(
                new LinkDto(_urlHelper.Link("PartiallyUpdateSkill", new { jobId, skillId }),
                "partially_update_skill",
                "PATCH"));

            links.Add(
                new LinkDto(_urlHelper.Link("DeleteSkill", new { skillId }),
                "delete_skill",
                "DELETE"));

            links.Add(
                new LinkDto(_urlHelper.Link("GetSkillsForJob", new { jobId }),
                "get_skills_for_job",
                "GET"));

            return links;
        } 
    }
}
