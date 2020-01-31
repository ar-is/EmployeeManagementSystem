using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.API.Utils.ResourceFilters
{
    public abstract class ResourceParameters
    {
        const int maxPageSize = 20;

        public virtual string OrderBy { get; set; }
        public string Fields { get; set; }
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }
}
