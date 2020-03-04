using EmployeeManagementSystem.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.API.Core.Interfaces.Services.Repositories
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(Guid employeeId);
        bool EmployeeExists(Guid employeeId);
        IEnumerable<Employee> GetEmployees();
        IEnumerable<Employee> GetEmployees(IEnumerable<Guid> employeeIds);
        void UpdateEmployee(Employee employee);
        void DeleteEmployees(IEnumerable<Employee> employees);
        void DeleteEmployee(Employee employee);
    }
}
