using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementSystem.API.Infrastructure.Migrations
{
    public partial class CreateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    SeniorityLevel = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    DepartmentId = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Surname = table.Column<string>(maxLength: 50, nullable: false),
                    HiringDate = table.Column<DateTimeOffset>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 14, nullable: false),
                    Email = table.Column<string>(maxLength: 254, nullable: false),
                    LatestSkillsetUpdate = table.Column<DateTimeOffset>(nullable: false),
                    LatestUpdate = table.Column<DateTimeOffset>(nullable: false),
                    JobId = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobSkill",
                columns: table => new
                {
                    SkillId = table.Column<short>(nullable: false),
                    JobId = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSkill", x => new { x.SkillId, x.JobId });
                    table.ForeignKey(
                        name: "FK_JobSkill_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobSkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 14, nullable: false),
                    Email = table.Column<string>(maxLength: 254, nullable: false),
                    ManagerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Employee_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSkill",
                columns: table => new
                {
                    SkillId = table.Column<short>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkill", x => new { x.SkillId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_EmployeeSkill_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Description", "Email", "Guid", "ManagerId", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { (short)1, "Logistics management is that part of the supply chain which plans, implements and controls the efficient, effective forward and reverse flow and storage of goods, services and related information between the point of origin and the point of consumption in order to meet customers' requirements.", "logistics@company.com", new Guid("a9eb16c3-d4d6-4280-89ad-8e1bba35be38"), null, "Logistics", "2101111111" },
                    { (short)2, "Software Development team specializes in the development of custom software applications and offshore software outsourcing services.", "swdev@company.com", new Guid("344ac739-b7ff-4b50-916b-77882688be7c"), null, "Software Development", "2102222222" },
                    { (short)3, "Human resources or HR is the department charged with finding, screening, recruiting, and training job applicants, and administering employee-benefit programs", "hr@company.com", new Guid("8a113a93-2051-490d-9329-bad2920e9b97"), null, "Human Resources (HR)", "2103333333" }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "CreationDate", "Description", "Guid", "Name", "Type" },
                values: new object[,]
                {
                    { (short)12, new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Javascript often abbreviated as JS, is a high-level, just-in-time compiled, multi-paradigm programming language that conforms to the ECMAScript specification.", new Guid("6bf0ba43-52eb-42b3-8e7e-e956813d0030"), "Javascript", 0 },
                    { (short)11, new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "SQL stands for Structured Query Language. SQL is used to communicate with a database.", new Guid("b9d648ef-0199-4813-bb46-3edae60316fa"), "SQL", 0 },
                    { (short)10, new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), ".NET Core is a free and open-source, managed computer software framework for Windows, Linux, and macOS operating systems. It is a cross-platform successor to .NET Framework.", new Guid("99f337c3-175e-44b5-bb6f-c21daef9320c"), ".NET Core", 0 },
                    { (short)9, new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "C# is a general-purpose, multi-paradigm programming language encompassing strong typing, lexically scoped, imperative, declarative, functional, generic, object-oriented (class-based), and component-oriented programming disciplines.", new Guid("7fde5249-3a4a-4b95-b8fc-81bc78cf848e"), "C#", 0 },
                    { (short)8, new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "OOP defines most modern server-side scripting languages, which are the languages back-end developers use to write software and database technology.", new Guid("caaf4435-c6de-436d-a941-8bf3f8d9ce38"), "OOP", 0 },
                    { (short)7, new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Source control helps the developer in managing and storing their code.", new Guid("1811edf9-c04b-4a09-80a9-8c28538a732c"), "Source Control (Git, TFS, etc.)", 0 },
                    { (short)6, new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Data Structures and Algorithms(e.g. array, linked list, tree) are the heart of programming as they improve the problem-solving ability of a candidate/employee to a great extent.", new Guid("5dc15297-6522-4363-9c1f-c78b597eb73e"), "Data Structures and Algorithms", 0 },
                    { (short)5, new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Work ethic is the ability to follow through on tasks and duties in a timely, quality manner. A strong work ethic will help ensure you develop a positive relationship with your employer and colleagues, even when you are still developing technical skills in a new job.", new Guid("8a113a93-2051-490d-9329-bad2920e9b97"), "Work ethic", 1 },
                    { (short)4, new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Employees who are capable of adapting to new situations and ways of working are valuable in many jobs and industries.", new Guid("d69b8478-b06a-4469-8540-4f0bffd9a3a1"), "Adaptability", 1 },
                    { (short)3, new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Employees with creativity can find new ways to perform tasks, improve processes or even develop new and exciting avenues for the business to explore.", new Guid("35534cb4-3e59-4edb-ab8d-da73caece421"), "Creativity", 1 },
                    { (short)2, new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Employers highly value people who can resolve issues quickly and effectively. That may involve calling on industry knowledge to fix an issue immediately as it occurs, or taking time to research and consult with colleagues to find a scalable, long-term solution.", new Guid("6bd53075-c359-4723-88e6-e942d04af82b"), "Problem-solving", 1 },
                    { (short)1, new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Effective communication skills will be helpful through the interview process and in your career overall. The ability to communicate involves knowing how you should speak to others in different situations or settings.", new Guid("57408e9a-9d0a-4df9-87df-fc4dbc8ab9e5"), "Communication", 1 },
                    { (short)13, new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Forward thinking helps you make accurate predictions of the possible needs of your company, as well as outcomes of actions made anywhere in the entire supply chain.", new Guid("f297e677-4614-41a6-8899-244205ef2f61"), "Forward Thinking", 1 },
                    { (short)14, new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "When it comes to working with other teams or units in the supply chain, it pays to treat everyone with respect and professionalism.", new Guid("53417bc5-a7c1-4bad-8393-78d79b263270"), "Team player", 1 }
                });

            migrationBuilder.InsertData(
                table: "Job",
                columns: new[] { "Id", "DepartmentId", "Description", "Guid", "SeniorityLevel", "Title" },
                values: new object[,]
                {
                    { (short)1, (short)1, "A logistics specialist is responsible for the oversight of the life cycle of products, including preparation, shipping and receiving.", new Guid("7b75a444-994d-4936-96bf-9c3c0804e42d"), 1, "Logistics Specialist" },
                    { (short)2, (short)1, "A logistics coordinator is responsible for managing all aspects of shipping routes and delivery, specifically with regard to customer satisfaction.", new Guid("a51f9b12-fb95-43e2-b010-733d53faf235"), 2, "Logistics Coordinator" },
                    { (short)3, (short)2, "A Junior Software Developer serves as a member of the software development team, aiding in the innovation and creation of company software and programs.", new Guid("4d459461-59da-473d-938e-f5c7c03d12d7"), 0, ".NET Software Developer" },
                    { (short)4, (short)2, "A Senior Software Developer serves as a leading member of the software development team, architecting towards innovation and creation of company software and programs.", new Guid("5c4a34ac-be45-4419-8a8b-612c020b38cf"), 2, ".NET Software Developer" },
                    { (short)5, (short)2, "IT Specialists, or Information Technology Specialists, install, monitor, and troubleshoot computer hardware and software systems.", new Guid("905d1d8f-d286-4ef2-a72e-c76353f342cb"), 2, "IT Specialist" },
                    { (short)6, (short)3, "A talent acquisition specialist is an HR professional who specializes in sourcing, identifying and hiring specific types of employees.", new Guid("ca6a17f8-2045-4113-bbdb-3230427ae5cd"), 1, "Talent Acquisition Recruiter" },
                    { (short)7, (short)3, "The responsibilities of human resources specialists revolve around the recruitment and placement of employees; therefore, their job duties may range from screening job candidates and conducting interviews to performing background checks and providing orientation to new employees.", new Guid("d64e4e3c-6d5b-4818-9039-246861177572"), 2, "HR Specialist" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Email", "Guid", "HiringDate", "JobId", "LatestSkillsetUpdate", "LatestUpdate", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { 8, "katerina.kastriti@company.com", new Guid("ce0de968-74e5-49cc-8f8b-e32b5ab6c8dc"), new DateTimeOffset(new DateTime(2019, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), (short)1, new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Katerina", "2101234567", "Kastriti" },
                    { 2, "dimitrios.konstantinou@company.com", new Guid("42bff182-7a27-4afb-b416-6ddec070a26f"), new DateTimeOffset(new DateTime(2017, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), (short)5, new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Dimitrios", "2105555555", "Konstantinou" },
                    { 4, "john.dunham@company.com", new Guid("2dcd69bf-d4bb-4964-afd0-5d6481a5028f"), new DateTimeOffset(new DateTime(2017, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), (short)4, new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "John", "2106666666", "Dunham" },
                    { 3, "eleni.dimitriou@company.com", new Guid("a4c16623-aa97-4846-93e5-6fdd3c486f0f"), new DateTimeOffset(new DateTime(2017, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), (short)2, new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Eleni", "2105555555", "Dimitriou" },
                    { 5, "konstantina.nikolaou@company.com", new Guid("14924b4e-8f1f-4221-b476-d850fb7147be"), new DateTimeOffset(new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), (short)6, new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Konstantina", "2107777777", "Nikolaou" },
                    { 1, "george.papadimitriou@company.com", new Guid("9dbc5eeb-6a83-46f9-92a4-23d8253f36cc"), new DateTimeOffset(new DateTime(2019, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), (short)3, new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Georgios", "2104444444", "Papadimitriou" },
                    { 6, "amy.roberts@company.com", new Guid("517f9706-11ca-4de9-8c94-05446aa07071"), new DateTimeOffset(new DateTime(2017, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), (short)3, new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Amy", "2108888888", "Roberts" },
                    { 7, "petros.stamatopoulos@company.com", new Guid("ec458a9c-3abb-42ff-99dd-03e2ad93206d"), new DateTimeOffset(new DateTime(2019, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), (short)3, new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Petros", "2109999999", "Stamatopoulos" }
                });

            migrationBuilder.InsertData(
                table: "JobSkill",
                columns: new[] { "SkillId", "JobId" },
                values: new object[,]
                {
                    { (short)12, (short)4 },
                    { (short)13, (short)4 },
                    { (short)1, (short)5 },
                    { (short)2, (short)5 },
                    { (short)4, (short)5 },
                    { (short)5, (short)5 },
                    { (short)8, (short)5 },
                    { (short)14, (short)5 },
                    { (short)13, (short)5 },
                    { (short)11, (short)4 },
                    { (short)1, (short)6 },
                    { (short)4, (short)6 },
                    { (short)5, (short)6 },
                    { (short)13, (short)6 },
                    { (short)14, (short)6 },
                    { (short)1, (short)7 },
                    { (short)2, (short)7 },
                    { (short)11, (short)5 },
                    { (short)10, (short)4 },
                    { (short)7, (short)4 },
                    { (short)8, (short)4 },
                    { (short)1, (short)1 },
                    { (short)2, (short)1 },
                    { (short)5, (short)1 },
                    { (short)13, (short)1 },
                    { (short)14, (short)1 },
                    { (short)1, (short)2 },
                    { (short)2, (short)2 },
                    { (short)5, (short)2 },
                    { (short)1, (short)3 },
                    { (short)9, (short)4 },
                    { (short)2, (short)3 },
                    { (short)6, (short)3 },
                    { (short)7, (short)3 },
                    { (short)8, (short)3 },
                    { (short)9, (short)3 },
                    { (short)14, (short)3 },
                    { (short)1, (short)4 },
                    { (short)2, (short)4 },
                    { (short)6, (short)4 },
                    { (short)3, (short)7 },
                    { (short)4, (short)3 },
                    { (short)13, (short)7 }
                });

            migrationBuilder.InsertData(
                table: "EmployeeSkill",
                columns: new[] { "SkillId", "EmployeeId" },
                values: new object[,]
                {
                    { (short)1, 8 },
                    { (short)9, 7 },
                    { (short)14, 7 },
                    { (short)1, 4 },
                    { (short)2, 4 },
                    { (short)6, 4 },
                    { (short)7, 4 },
                    { (short)8, 4 },
                    { (short)9, 4 },
                    { (short)10, 4 },
                    { (short)11, 4 },
                    { (short)12, 4 },
                    { (short)13, 4 },
                    { (short)1, 2 },
                    { (short)8, 7 },
                    { (short)2, 2 },
                    { (short)5, 2 },
                    { (short)6, 2 },
                    { (short)7, 2 },
                    { (short)8, 2 },
                    { (short)9, 2 },
                    { (short)10, 2 },
                    { (short)11, 2 },
                    { (short)12, 2 },
                    { (short)13, 2 },
                    { (short)14, 2 },
                    { (short)1, 5 },
                    { (short)4, 5 },
                    { (short)5, 5 },
                    { (short)4, 2 },
                    { (short)7, 7 },
                    { (short)6, 7 },
                    { (short)4, 7 },
                    { (short)2, 8 },
                    { (short)4, 8 },
                    { (short)5, 8 },
                    { (short)13, 8 },
                    { (short)14, 8 },
                    { (short)1, 3 },
                    { (short)2, 3 },
                    { (short)3, 3 },
                    { (short)5, 3 },
                    { (short)13, 3 },
                    { (short)1, 1 },
                    { (short)2, 1 },
                    { (short)4, 1 },
                    { (short)6, 1 },
                    { (short)7, 1 },
                    { (short)8, 1 },
                    { (short)9, 1 },
                    { (short)12, 1 },
                    { (short)14, 1 },
                    { (short)1, 6 },
                    { (short)2, 6 },
                    { (short)4, 6 },
                    { (short)6, 6 },
                    { (short)7, 6 },
                    { (short)8, 6 },
                    { (short)9, 6 },
                    { (short)14, 6 },
                    { (short)1, 7 },
                    { (short)2, 7 },
                    { (short)13, 5 },
                    { (short)14, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "Guid",
                table: "Department",
                column: "Guid")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_Department_ManagerId",
                table: "Department",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "Guid",
                table: "Employee",
                column: "Guid")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_JobId",
                table: "Employee",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkill_EmployeeId",
                table: "EmployeeSkill",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_DepartmentId",
                table: "Job",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "Guid",
                table: "Job",
                column: "Guid")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_JobSkill_JobId",
                table: "JobSkill",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "Guid",
                table: "Skill",
                column: "Guid")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Department_DepartmentId",
                table: "Job",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Employee_ManagerId",
                table: "Department");

            migrationBuilder.DropTable(
                name: "EmployeeSkill");

            migrationBuilder.DropTable(
                name: "JobSkill");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
