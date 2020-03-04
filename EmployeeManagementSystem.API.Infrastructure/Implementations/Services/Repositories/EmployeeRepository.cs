using EmployeeManagementSystem.API.Core.Entities;
using EmployeeManagementSystem.API.Core.Interfaces.Services.Repositories;
using EmployeeManagementSystem.API.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeManagementSystem.API.Infrastructure.Implementations.Services.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EMSDbContext _context;

        public EmployeeRepository(EMSDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool EmployeeExists(Guid employeeId)
        {
            if (employeeId == Guid.Empty)
                throw new ArgumentNullException(nameof(employeeId));

            return _context.Employees.Any(e => e.Guid == employeeId);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees
                .Include(e => e.Job)
                .ToList();
        }

        public Employee GetEmployee(Guid employeeId)
        {
            if (employeeId == Guid.Empty)
                throw new ArgumentNullException(nameof(employeeId));

            return _context.Employees
                .Include(e => e.Job)
                .Include(e => e.EmployeeSkills)
                    .ThenInclude(es => es.Skill)
                .FirstOrDefault(e => e.Guid == employeeId);
        }

        public void DeleteEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            _context.Employees.Remove(employee);
        }

        public IEnumerable<Employee> GetEmployees(IEnumerable<Guid> employeeIds)
        {
            return _context.Employees
                .Where(d => employeeIds.Contains(d.Guid))
                .ToList();
        }

        public void UpdateEmployee(Employee employee)
        {

        }

        public void DeleteEmployees(IEnumerable<Employee> employees)
        {
            foreach (var employee in employees)
            {
                _context.Employees.Remove(employee);

                var department = _context.Departments.SingleOrDefault(d => d.ManagerId == employee.Id);

               if (department != null)
                    department.ManagerId = null;
            }
        }
    }
}
