using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "leaveType",
                keyColumn: "Id",
                keyValue: new Guid("c7accea6-65f7-4260-9241-ec18cb4ca01c"));

            migrationBuilder.CreateTable(
                name: "studentAttendances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentAttendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_studentAttendances_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_studentAttendances_StudentsId",
                table: "studentAttendances",
                column: "StudentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studentAttendances");

            migrationBuilder.InsertData(
                table: "leaveType",
                columns: new[] { "Id", "CountPerYear", "IsActive", "LeaveBalanceId", "Name" },
                values: new object[] { new Guid("c7accea6-65f7-4260-9241-ec18cb4ca01c"), 0, true, null, "No Pay Leave" });
        }
    }
}
