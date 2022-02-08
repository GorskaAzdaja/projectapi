using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectAPI.Migrations
{
    public partial class Database_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Start_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Completion_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Project_Status = table.Column<int>(type: "int", nullable: false),
                    Project_Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Task_Status = table.Column<int>(type: "int", nullable: false),
                    Task_Priority = table.Column<int>(type: "int", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectID", "Completion_Date", "Name", "Project_Priority", "Project_Status", "Start_Date" },
                values: new object[] { 1, null, "First Project", 2, 1, new DateTime(2022, 2, 8, 19, 4, 31, 961, DateTimeKind.Local).AddTicks(4086) });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectID", "Completion_Date", "Name", "Project_Priority", "Project_Status", "Start_Date" },
                values: new object[] { 2, new DateTime(2022, 2, 8, 19, 4, 31, 961, DateTimeKind.Local).AddTicks(4132), "Second Project", 1, 2, new DateTime(2022, 2, 8, 19, 4, 31, 961, DateTimeKind.Local).AddTicks(4129) });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskID", "Description", "Name", "ProjectID", "Task_Priority", "Task_Status" },
                values: new object[] { 1, "Some description 1", "First task in first project", 1, 0, 0 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskID", "Description", "Name", "ProjectID", "Task_Priority", "Task_Status" },
                values: new object[] { 2, "Some description 2", "Second task in first project", 1, 2, 1 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskID", "Description", "Name", "ProjectID", "Task_Priority", "Task_Status" },
                values: new object[] { 3, "Some description 3", "Third task in second project", 2, 1, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectID",
                table: "Tasks",
                column: "ProjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
