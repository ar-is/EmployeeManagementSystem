using AutoMapper;
using EmployeeManagementSystem.API.Core.Dtos.Skills;
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
    [Route("api/employeecollections")]
    public class EmployeeCollectionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeCollectionsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("({ids})", Name = "GetEmployeeCollection")]
        public IActionResult GetEmployeeCollection(
            [FromRoute]
            [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (!ids.Any())
                return BadRequest();

            var employeeEntities = _unitOfWork.Employees.GetEmployees(ids);

            if (ids.Count() != employeeEntities.Count())
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employeeEntities));
        }

        [HttpDelete("({ids})", Name = "DeleteEmployeeCollection")]
        public IActionResult DeleteEmployeeCollection(
            [FromRoute]
            [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (!ids.Any())
                return BadRequest();

            var employeeEntities = _unitOfWork.Employees.GetEmployees(ids);

            if (ids.Count() != employeeEntities.Count())
                return NotFound();

            _unitOfWork.e

            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employeeEntities));
        }
    }
}
