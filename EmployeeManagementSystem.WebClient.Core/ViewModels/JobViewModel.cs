using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.WebClient.Core.ViewModels
{
    public class JobViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string SeniorityLevel { get; set; }
    }
}
