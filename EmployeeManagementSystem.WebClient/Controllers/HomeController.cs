using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmployeeManagementSystem.WebClient.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeManagementSystem.WebClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
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
        public RedirectToActionResult Skills(JobSkillViewModel viewModel = null)
        {
            return RedirectToAction("Skills", new { jobId = viewModel.JobId });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
