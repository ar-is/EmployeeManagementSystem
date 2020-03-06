using AutoMapper;
using EmployeeManagementSystem.API.Core.Dtos.Skills;
using EmployeeManagementSystem.API.Core.Entities;
using EmployeeManagementSystem.API.Core.Interfaces.Services;
using EmployeeManagementSystem.API.Utils.CustomModelBinders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/skillcollections")]
    public class SkillCollectionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SkillCollectionsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("({ids})", Name = "GetSkillCollection")]
        public IActionResult GetSkillCollection(
            [FromRoute]
            [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (!ids.Any())
                return BadRequest();

            var skillEntities = _unitOfWork.Skills.GetSkills(ids);

            if (ids.Count() != skillEntities.Count())
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<SkillDto>>(skillEntities));
        }

        [HttpPost(Name = "CreateSkillCollection")]
        public ActionResult<IEnumerable<SkillDto>> CreateSkillsCollection(
            IEnumerable<SkillForCreationDto> skillCollection)
        {
            var skillEntities = _mapper.Map<IEnumerable<Skill>>(skillCollection);

            if (_unitOfWork.Skills.ContainsDuplicates(skillEntities))
                return Conflict(new { message = $"You can't post the same skill twice" });

            skillEntities.ToList().ForEach(s => _unitOfWork.Skills.AddSkill(s));
            _unitOfWork.Complete();

            var skillCollectionToReturn = _mapper.Map<IEnumerable<SkillDto>>(skillEntities);
            var idsAsString = string.Join(",", skillCollectionToReturn.Select(s => s.Id));

            return CreatedAtRoute("GetSkillCollection",
                                  new { ids = idsAsString },
                                  skillCollectionToReturn);
        }
    }
}
