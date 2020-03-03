using AutoMapper;
using EmployeeManagementSystem.API.Core.Dtos.Skills;
using EmployeeManagementSystem.API.Core.Entities;
using EmployeeManagementSystem.API.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "GetEmployees")]
        public ActionResult<IEnumerable<EmployeeDto>> GetEmployees()
        {
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(_unitOfWork.Employees.GetEmployees()));
        }

        [HttpGet("{employeeId}", Name = "GetEmployee")]
        public ActionResult<EmployeeFullDto> GetEmployee(Guid employeeId)
        {
            var employee = _unitOfWork.Employees.GetEmployee(employeeId);

            if (employee == null)
                return NotFound();

            var mappedSkills = new List<Skill>();
            employee.EmployeeSkills.ToList().ForEach(es => mappedSkills.Add(es.Skill));
            var employeeDtoToReturn = _mapper.Map<EmployeeFullDto>(employee);
            mappedSkills.ForEach(ms => employeeDtoToReturn.Skills.Add(_mapper.Map<SkillDto>(ms)));

            return employeeDtoToReturn;
        }
    }
}
