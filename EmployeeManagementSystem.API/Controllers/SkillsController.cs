using AutoMapper;
using EmployeeManagementSystem.API.Core.Dtos.Skills;
using EmployeeManagementSystem.API.Core.Entities;
using EmployeeManagementSystem.API.Core.Interfaces.Services;
using EmployeeManagementSystem.API.Core.Interfaces.Services.Data_Shaping;
using EmployeeManagementSystem.API.Core.Interfaces.Services.Pagination;
using EmployeeManagementSystem.API.Core.Interfaces.Services.Sorting;
using EmployeeManagementSystem.API.Utils.ResourceFilters.Skills;
using EmployeeManagementSystem.API.Utils.VendorMediaTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/jobs/{jobId}/skills")]
    public class SkillsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPropertyMappingService _propertyMappingService;
        private readonly IPropertyCheckerService _propertyCheckerService;
        private readonly IPaginationService<Skill> _paginationService;
        private readonly IDataShapingService<Skill> _dataShapingService;
        private readonly IDependentEntityPaginationService<Skill> _dependentLinksService;

        public SkillsController(IUnitOfWork unitOfWork, IMapper mapper,
            IPropertyMappingService propertyMappingService,
            IPropertyCheckerService propertyCheckerService,
            IPaginationService<Skill> paginationService,
            IDependentEntityPaginationService<Skill> dependentLinksService,
            IDataShapingService<Skill> dataShapingService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _propertyMappingService = propertyMappingService ??
                throw new ArgumentNullException(nameof(propertyMappingService));
            _propertyCheckerService = propertyCheckerService ??
                throw new ArgumentNullException(nameof(propertyCheckerService));
            _paginationService = paginationService ??
                throw new ArgumentNullException(nameof(paginationService));
            _dependentLinksService = dependentLinksService
                ?? throw new ArgumentNullException(nameof(dependentLinksService));
            _dataShapingService = dataShapingService
                ?? throw new ArgumentNullException(nameof(dataShapingService));
        }

        [Produces(MediaTypes.Json,
            MediaTypes.HateoasPlusJson,
            SkillMediaTypes.FullSkillJson,
            SkillMediaTypes.FullSkillHateoasPlusJson,
            SkillMediaTypes.FriendlySkillJson,
            SkillMediaTypes.FriendlySkillHateoasPlusJson)]
        [HttpGet(Name = "GetSkillsForJob")]
        public ActionResult<IEnumerable<SkillDto>> GetSkillsForJob(Guid jobId,
            [FromQuery] SkillsResourceParameters parameters,
            [FromHeader(Name = "Accept")] string mediaType)
        {
            if (!_unitOfWork.Jobs.JobExists(jobId))
                return NotFound();

            if (mediaType.Contains("full"))
            {
                if (!_propertyCheckerService.TypeHasProperties<SkillFullDto>(parameters.Fields))
                    return BadRequest();
            }

            if (!MediaTypeHeaderValue.TryParse(mediaType, out MediaTypeHeaderValue parsedMediaType))
                return BadRequest();

            if (!_propertyMappingService.ValidMappingExistsFor<SkillDto, Skill>(parameters.OrderBy) ||
                !_propertyCheckerService.TypeHasProperties<SkillDto>(parameters.Fields))
                return BadRequest();

            if (!string.IsNullOrEmpty(parameters.Fields) && !parameters.Fields.Contains("id"))
                return BadRequest();

            var skills = _unitOfWork.Skills.GetSkills(jobId, parameters);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(
                    _paginationService.CreatePaginationMetadata(skills, parameters)));

            return Ok(_dataShapingService.GetShapedCollection(skills, parameters, parsedMediaType));
        }
    }
}
