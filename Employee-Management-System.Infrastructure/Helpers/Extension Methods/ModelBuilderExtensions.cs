using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Employee_Management_System.Infrastructure.Helpers.Extension_Methods
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
