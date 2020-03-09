using AutoMapper;
using EmployeeManagementSystem.API.Core.Dtos.Employees;
using EmployeeManagementSystem.API.Core.Dtos.Skills;
using EmployeeManagementSystem.API.Core.Entities;
using EmployeeManagementSystem.API.Core.Interfaces.Services;
using EmployeeManagementSystem.API.Utils.CustomModelBinders;
using Microsoft.AspNetCore.JsonPatch;
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

        //[HttpGet(Name = "GetEmployees")]
        //public ActionResult<IEnumerable<EmployeeDto>> GetEmployees()
        //{
        //    return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(_unitOfWork.Employees.GetEmployees()));
        //}

        [HttpGet(Name = "GetEmployees")]
        public ActionResult<IEnumerable<EmployeeDto>> GetEmployees(
            [FromQuery]
            [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> skillGuids)
        {
            if (skillGuids == null || !skillGuids.Any())
                return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(_unitOfWork.Employees.GetEmployees()));

            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(_unitOfWork.Employees.GetEmployeesBySkills(skillGuids)));
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

        [HttpPost(Name = "CreateEmployee")]
        public IActionResult CreateEmployee(EmployeeForCreationDto employee)
        {
            var employeeEntity = MapRelatedCollectionOnCreation(employee);

            if (_unitOfWork.Employees.EmployeeExists(employeeEntity))
                return Conflict(new { message = $"This Employee already exists in the database!" });

            _unitOfWork.Employees.AddEmployee(employeeEntity);
            _unitOfWork.Complete();

            var employeeToReturn = _mapper.Map<EmployeeFullDto>(employeeEntity);

            return CreatedAtRoute("GetEmployee",
                                  new { employeeId = employeeToReturn.Id },
                                        employeeToReturn);
        }

        private Employee MapRelatedCollectionOnCreation(EmployeeForCreationDto employee)
        {
            var employeeEntity = _mapper.Map<Employee>(employee);
            var mappedEmployeeSkills = new List<EmployeeSkill>();
            employee.EmployeeSkills.ToList().ForEach(es => mappedEmployeeSkills.Add(new EmployeeSkill() { SkillId = _unitOfWork.Skills.GetSkill(es.SkillId).Id }));
            mappedEmployeeSkills.ForEach(es => employeeEntity.EmployeeSkills.Add(es));

            var jobId = _unitOfWork.Jobs.GetJob(employee.JobId).Id;
            employeeEntity.JobId = jobId;

            return employeeEntity;
        }

        [HttpPatch("{employeeId}", Name = "PartiallyUpdateEmployee")]
        public IActionResult PartiallyUpdateEmployee(Guid employeeId,
           JsonPatchDocument<EmployeeForUpdateDto> patchDocument)
        {
            var employeeFromDb = _unitOfWork.Employees.GetEmployee(employeeId);

            if (employeeFromDb == null)
                return NotFound();

            var employeeToPatch = _mapper.Map<EmployeeForUpdateDto>(employeeFromDb);
            patchDocument.ApplyTo(employeeToPatch, ModelState);

            if (!TryValidateModel(employeeToPatch))
                return ValidationProblem(ModelState);

            _mapper.Map(employeeToPatch, employeeFromDb);
            MapRelatedCollectionOnPatch(employeeToPatch, ref employeeFromDb);

            _unitOfWork.Employees.UpdateEmployee(employeeFromDb);
            _unitOfWork.Complete();

            return NoContent();
        }

        private void MapRelatedCollectionOnPatch(EmployeeForUpdateDto employeeToPatch,
            ref Employee employeeFromDb)
        {
            var employeeToPatchSkillIds = new HashSet<Guid>();
            employeeToPatch.EmployeeSkills.ToList().ForEach(es => employeeToPatchSkillIds.Add(es.SkillId));
            var employeeFromDbSkillIds = new HashSet<Guid>();
            employeeFromDb.EmployeeSkills.ToList().ForEach(es => employeeFromDbSkillIds.Add(es.Skill.Guid));

            if (!employeeToPatchSkillIds.SetEquals(employeeFromDbSkillIds))
            {
                employeeFromDb.EmployeeSkills.Clear();
                var mappedEmployeeSkills = new List<EmployeeSkill>();
                employeeToPatch.EmployeeSkills.ToList().ForEach(es => mappedEmployeeSkills.Add(new EmployeeSkill() { SkillId = _unitOfWork.Skills.GetSkill(es.SkillId).Id }));

                foreach (var employeeSkill in mappedEmployeeSkills)
                    employeeFromDb.EmployeeSkills.Add(employeeSkill);

                employeeFromDb.UpdateSkillsetDate();
            }
        }

        [HttpDelete("{employeeId}", Name = "DeleteEmployee")]
        public ActionResult DeleteEmployee(Guid employeeId)
        {
            var employeeFromDb = _unitOfWork.Employees.GetEmployee(employeeId);

            if (employeeFromDb == null)
                return NotFound();

            _unitOfWork.Employees.DeleteEmployee(employeeFromDb);
            _unitOfWork.Complete();

            return NoContent();
        }
    }
}
