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
    public class SkillsController : Controller
    {
        [Authorize(Roles = "Scheduler")]
        public ViewResult AllSkills(string type, string status)
        {
            return View(new AllSkillsViewModel { Type = type, Status = status });
        }

        [HttpPost]
        [Authorize(Roles = "Scheduler")]
        public RedirectToActionResult AllSkills(AllSkillsViewModel viewModel)
        {
            return RedirectToAction("AllSkills", new { type = viewModel.Type, status = viewModel.Status });
        }

        [Authorize(Roles = "Scheduler")]
        public ViewResult Skills(Guid jobId)
        {
            if (jobId == Guid.Empty)
                jobId = Guid.Parse("7b75a444-994d-4936-96bf-9c3c0804e42d");

            return View(new JobSkillViewModel { JobId = jobId });
        }

        [HttpPost]
        [Authorize(Roles = "Scheduler")]
        public RedirectToActionResult Skills(JobSkillViewModel viewModel)
        {
            return RedirectToAction("Skills", new { jobId = viewModel.JobId });
        }

        [Authorize(Roles = "Scheduler")]
        [Route("Skills/SkillDetails/{id:guid}")]
        public ViewResult SkillDetails(Guid id)
        {
            var t = Task.Run(() => GetURI(new Uri("http://localhost:5001/api/skills/" + id)));
            t.Wait();

            var skill = JsonConvert.DeserializeObject<SkillViewModel>(t.Result);

            return View(skill);
        }

        static async Task<string> GetURI(Uri u)
        {
            var response = string.Empty;

            using var client = new HttpClient();

            HttpResponseMessage result = await client.GetAsync(u);

            if (result.IsSuccessStatusCode)
                response = await result.Content.ReadAsStringAsync();

            return response;
        }

        [Authorize(Roles = "Scheduler")]
        public ViewResult CreateSkill()
        {
            var t = Task.Run(() => GetURI(new Uri("http://localhost:5001/api/jobs/")));
            t.Wait();

            var jobs = JsonConvert.DeserializeObject<IEnumerable<JobViewModel>>(t.Result);

            return View("SkillForm", new SkillViewModel() { Jobs = jobs });
        }
    }
}
