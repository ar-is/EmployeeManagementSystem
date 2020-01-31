using AutoMapper;
using EmployeeManagementSystem.API.Core.Dtos.Skills;
using EmployeeManagementSystem.API.Core.Entities;
using EmployeeManagementSystem.API.Core.Interfaces.Services.Data_Shaping;
using EmployeeManagementSystem.API.Core.Interfaces.Services.Pagination;
using EmployeeManagementSystem.API.Utils.Paging;
using EmployeeManagementSystem.API.Utils.ResourceFilters;
using EmployeeManagementSystem.API.Infrastructure.Helpers.Extension_Methods;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EmployeeManagementSystem.API.Utils.VendorMediaTypes;
using EmployeeManagementSystem.API.Utils.Extension_Methods;

namespace EmployeeManagementSystem.API.Infrastructure.Implementations.Services.Data_Shaping
{
    public class SkillShapingService : IDataShapingService<Skill>
    {
        private readonly IPaginationService<Skill> _paginationService;
        private readonly IMapper _mapper;

        public SkillShapingService(IPaginationService<Skill> paginationService, IMapper mapper)
        {
            _paginationService = paginationService
                ?? throw new ArgumentNullException(nameof(paginationService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public object GetShapedCollection(PagedList<Skill> skills,
            ResourceParameters resourceParameters, MediaTypeHeaderValue parsedMediaType)
        {
            if (_paginationService.GetPrimaryMediaType(parsedMediaType) == SkillMediaTypes.PrimaryFullSkill)
                return GetFullShapedCollection(skills, resourceParameters, parsedMediaType);

            return GetCustomShapedCollection(skills, resourceParameters, parsedMediaType);
        }

        private object GetCustomShapedCollection(PagedList<Skill> skills, ResourceParameters resourceParameters, MediaTypeHeaderValue parsedMediaType)
        {
            var shapedSkills = _mapper.Map<IEnumerable<SkillDto>>(skills)
                                                  .ShapeData(resourceParameters.Fields);

            if (_paginationService.IncludeLinks(parsedMediaType))
            {
                var shapedSkillsWithLinks = shapedSkills.Select(skill =>
                {
                    var skillAsDictionary = skill as IDictionary<string, object>;
                    var skillLinks = _paginationService.CreateLinksForEntity((Guid)skillAsDictionary["Id"], null);
                    skillAsDictionary.Add("links", skillLinks);
                    return skillAsDictionary;
                });

                return new
                {
                    value = shapedSkillsWithLinks,
                    links = _paginationService.CreateLinksForEntities(resourceParameters, skills.HasNext, skills.HasPrevious)
                };
            }

            return shapedSkills;
        }

        private object GetFullShapedCollection(PagedList<Skill> skills, ResourceParameters resourceParameters, MediaTypeHeaderValue parsedMediaType)
        {
            var shapedFullSkills = _mapper.Map<IEnumerable<SkillFullDto>>(skills)
                                .ShapeData(resourceParameters.Fields);

            if (_paginationService.IncludeLinks(parsedMediaType))
            {
                var shapedFullSkillsWithLinks = shapedFullSkills.Select(fullSkill =>
                {
                    var fullSkillAsDictionary = fullSkill as IDictionary<string, object>;
                    var fullSkillLinks = _paginationService.CreateLinksForEntity((Guid)fullSkillAsDictionary["Id"], null);
                    fullSkillAsDictionary.Add("links", fullSkillLinks);
                    return fullSkillAsDictionary;
                });

                return new
                {
                    value = shapedFullSkillsWithLinks,
                    links = _paginationService.CreateLinksForEntities(resourceParameters, skills.HasNext, skills.HasPrevious)
                };
            }

            return shapedFullSkills;
        }

        public IDictionary<string, object> GetShapedEntity(MediaTypeHeaderValue parsedMediaType,
            Skill performance, string fields)
        {
            if (_paginationService.GetPrimaryMediaType(parsedMediaType) == SkillMediaTypes.PrimaryFullSkill)
            {
                var fullResourceToReturn = _mapper.Map<SkillFullDto>(performance)
                    .ShapeData(fields) as IDictionary<string, object>;

                if (_paginationService.IncludeLinks(parsedMediaType))
                    fullResourceToReturn.Add("links", _paginationService.CreateLinksForEntity(performance.Guid, fields));

                return fullResourceToReturn;
            }

            var friendlyResourceToReturn = _mapper.Map<SkillDto>(performance)
                .ShapeData(fields) as IDictionary<string, object>;

            if (_paginationService.IncludeLinks(parsedMediaType))
                friendlyResourceToReturn.Add("links", _paginationService.CreateLinksForEntity(performance.Guid, fields));

            return friendlyResourceToReturn;
        }
    }
}
