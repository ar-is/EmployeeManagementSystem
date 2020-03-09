﻿using EmployeeManagementSystem.API.Core.Entities;
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

        public bool EmployeeExists(Employee employee)
        {
            return _context.Employees.Any(e => e.Name == employee.Name &&
                                            e.Surname == employee.Surname &&
                                            e.Email == employee.Email);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees
                .Include(e => e.Job)
                    .ThenInclude(j => j.Department)
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

        public IEnumerable<Employee> GetEmployees(IEnumerable<Guid> employeeIds)
        {
            if (!employeeIds.Any())
                throw new ArgumentNullException(nameof(employeeIds));

            return _context.Employees
                .Where(d => employeeIds.Contains(d.Guid))
                .ToList();
        }

        public IEnumerable<Employee> GetEmployeesBySkills(IEnumerable<Guid> skillGuids)
        {
            if (!skillGuids.Any())
                throw new ArgumentNullException(nameof(skillGuids));

            var skillPks = new HashSet<short>();

            foreach (var skillGuid in skillGuids)
            {
                var skill = _context.Skills.FirstOrDefault(s => s.Guid == skillGuid);

                if (skill == null)
                    throw new ArgumentNullException(nameof(skill));

                skillPks.Add(skill.Id);
            }

            return _context.EmployeeSkills
                .Include(es => es.Employee)
                .Where(es => skillPks.Contains(es.SkillId))
                .Select(es => es.Employee)
                //.Include(e => e.Job)
                //    .ThenInclude(j => j.Department)
                .ToList();
        }

        public void AddEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            if (employee.Guid == Guid.Empty)
                employee.Guid = Guid.NewGuid();

            _context.Employees.Add(employee);
        }

        public void UpdateEmployee(Employee employee)
        {

        }

        public void DeleteEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            _context.Employees.Remove(employee);
        }

        public void DeleteEmployees(IEnumerable<Employee> employees)
        {
            if (!employees.Any())
                throw new ArgumentNullException(nameof(employees));

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
