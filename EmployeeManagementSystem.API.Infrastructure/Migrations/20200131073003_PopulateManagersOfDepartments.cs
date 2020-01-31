using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementSystem.API.Infrastructure.Migrations
{
    public partial class PopulateManagersOfDepartments : Migration
    {
        protected override void Up(MigrationBuilder builder)
        {
            builder.Sql("UPDATE Department SET ManagerId = 3 WHERE Id = 1");
            builder.Sql("UPDATE Department SET ManagerId = 2 WHERE Id = 2");
        }

        protected override void Down(MigrationBuilder builder)
        {
            builder.Sql("UPDATE Department SET ManagerId = NULL WHERE Id = 1");
            builder.Sql("UPDATE Department SET ManagerId = NULL WHERE Id = 2");
        }
    }
}
