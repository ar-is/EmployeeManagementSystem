using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManagementSystem.Infrastructure.EntityConfigurations;

namespace EmployeeManagementSystem.Infrastructure.Helpers.Extension_Methods
{
    public static class ModelBuilderExtensions
    {
        public static void RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
                entity.SetTableName(entity.DisplayName());
        }
    }
}
