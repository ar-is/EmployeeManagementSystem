using EmployeeManagementSystem.WebClient.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.WebClient.Controllers
{
    [Authorize(Roles = "Scheduler")]
    public class EmployeesController :  Controller
    {
        public ViewResult AllEmployees()
        {
            return View();
        }
    }
}
