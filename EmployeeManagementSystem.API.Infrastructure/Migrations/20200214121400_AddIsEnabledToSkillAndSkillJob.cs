using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementSystem.API.Infrastructure.Migrations
{
    public partial class AddIsEnabledToSkillAndSkillJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Skill",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "JobSkill",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)1, (short)1 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)1, (short)2 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)1, (short)3 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)1, (short)4 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)1, (short)5 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)1, (short)6 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)1, (short)7 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)2, (short)1 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)2, (short)2 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)2, (short)3 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)2, (short)4 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)2, (short)5 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)2, (short)7 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)3, (short)7 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)4, (short)3 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)4, (short)5 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)4, (short)6 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)5, (short)1 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)5, (short)2 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)5, (short)5 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)5, (short)6 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)6, (short)3 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)6, (short)4 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)7, (short)3 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)7, (short)4 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)8, (short)3 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)8, (short)4 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)8, (short)5 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)9, (short)3 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)9, (short)4 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)10, (short)4 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)11, (short)4 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)11, (short)5 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)12, (short)4 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)13, (short)1 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)13, (short)4 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)13, (short)5 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)13, (short)6 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)13, (short)7 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)14, (short)1 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)14, (short)3 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)14, (short)5 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "JobSkill",
                keyColumns: new[] { "SkillId", "JobId" },
                keyValues: new object[] { (short)14, (short)6 },
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: (short)1,
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: (short)2,
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: (short)3,
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: (short)4,
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: (short)5,
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: (short)6,
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: (short)7,
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: (short)8,
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: (short)9,
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: (short)10,
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: (short)11,
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: (short)12,
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: (short)13,
                column: "IsEnabled",
                value: true);

            migrationBuilder.UpdateData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: (short)14,
                column: "IsEnabled",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "JobSkill");
        }
    }
}
