using AutoMapper;
using Employee_Management_System.Core.Dtos.Skills;
using Employee_Management_System.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management_System.API.Controllers
{
    [ApiController]
    [Route("api/jobs/{jobId}/skills")]
    public class SkillsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SkillsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "GetSkillsForJob")]
        public ActionResult<IEnumerable<SkillDto>> GetSkillsForJob(Guid jobId)
        {
            if (!_unitOfWork.Jobs.JobExists(jobId))
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<SkillDto>>(_unitOfWork.Skills.GetSkills(jobId)));
        }
    }
}
