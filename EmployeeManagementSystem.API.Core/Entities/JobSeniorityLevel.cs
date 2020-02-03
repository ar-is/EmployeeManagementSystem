using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.API.Core.Entities
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum JobSeniorityLevel
    {
        Junior,
        Mid,
        Senior
    }
}
