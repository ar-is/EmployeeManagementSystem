using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementSystem.WebClient.Infrastructure.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "AspNetRoles",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Guid", "Name", "NormalizedName" },
                values: new object[] { 1, "4e496f5c-2d29-4816-8f33-dc3ad38c1141", new Guid("a81e61ce-607f-43fd-ad39-fd6c6d784730"), "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Guid", "Name", "NormalizedName" },
                values: new object[] { 2, "7c561a61-1cc4-451b-9eb9-56f031065107", new Guid("62714b07-3dd0-4a27-9a76-b13fb1815451"), "Scheduler", "SCHEDULER" });

            migrationBuilder.CreateIndex(
                name: "Guid",
                table: "AspNetRoles",
                column: "Guid")
                .Annotation("SqlServer:Clustered", false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Guid",
                table: "AspNetRoles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "AspNetRoles");
        }
    }
}
