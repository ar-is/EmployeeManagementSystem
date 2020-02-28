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

        public EmployeeCollectionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        [HttpDelete(Name = "DeleteEmployeeCollection")]
        public IActionResult DeleteEmployeeCollection(
            [FromQuery]
            [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null || !ids.Any())
                return BadRequest();

            var employeeEntities = _unitOfWork.Employees.GetEmployees(ids);

            if (ids.Count() != employeeEntities.Count())
                return NotFound();

            _unitOfWork.Employees.DeleteEmployees(employeeEntities);
            _unitOfWork.Complete();

            return NoContent();
        }
    }
}
