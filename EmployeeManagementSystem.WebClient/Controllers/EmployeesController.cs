using EmployeeManagementSystem.WebClient.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.WebClient.Controllers
{
    [Authorize(Roles = "Scheduler")]
    public class EmployeesController :  Controller
    {
        [Route("Employees/{employeeId:guid}")]
        public IActionResult Index(Guid? employeeId)
        {
            if (employeeId == null)
                return RedirectToAction("AllEmployees");

            var employeeTask = Task.Run(() => GetURI(new Uri("http://localhost:5001/api/employees/" + employeeId)));
            employeeTask.Wait();

            var employee = JsonConvert.DeserializeObject<EmployeeViewModel>(employeeTask.Result);

            var skillsTask = Task.Run(() => GetURI(new Uri("http://localhost:5001/api/skills/")));
            skillsTask.Wait();

            employee.AllSkills = JsonConvert.DeserializeObject<ICollection<SkillViewModel>>(skillsTask.Result);

            return View(employee);
        }

        public ViewResult AllEmployees(string skillIds)
        {
            return View(new AllEmployeesViewModel { SkillIds = skillIds });
        }

        [HttpPost]
        public RedirectToActionResult AllEmployees(AllEmployeesViewModel viewModel)
        {
            return RedirectToAction("AllEmployees", new { skillIds = viewModel.SkillIds });
        }

        static async Task<string> GetURI(Uri u)
        {
            var response = string.Empty;

            using var client = new HttpClient();

            HttpResponseMessage result = null;

            try
            {
                result = await client.GetAsync(u);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (result.IsSuccessStatusCode)
                response = await result.Content.ReadAsStringAsync();

            return response;
        }

        public ViewResult CreateEmployee()
        {
            var employeeViewModel = new EmployeeViewModel();

            var skillsTask = Task.Run(() => GetURI(new Uri("http://localhost:5001/api/skills/")));
            skillsTask.Wait();

            employeeViewModel.Skills = JsonConvert.DeserializeObject<ICollection<SkillViewModel>>(skillsTask.Result);

            var jobsTask = Task.Run(() => GetURI(new Uri("http://localhost:5001/api/jobs/")));
            jobsTask.Wait();

            employeeViewModel.AllJobs = JsonConvert.DeserializeObject<ICollection<JobViewModel>>(jobsTask.Result);

            return View("EmployeeForm", employeeViewModel);
        }
    }
}
