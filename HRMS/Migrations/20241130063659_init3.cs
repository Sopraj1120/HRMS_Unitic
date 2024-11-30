using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "leaveType",
                keyColumn: "Id",
                keyValue: new Guid("df381250-5038-46ff-b035-f94b683cac69"));

            migrationBuilder.DropColumn(
                name: "Weekdays",
                table: "workingDays");

            migrationBuilder.CreateTable(
                name: "WeekWorkingDays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkingDaysId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Weekday = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekWorkingDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeekWorkingDays_workingDays_WorkingDaysId",
                        column: x => x.WorkingDaysId,
                        principalTable: "workingDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "leaveType",
                columns: new[] { "Id", "CountPerYear", "IsActive", "LeaveBalanceId", "Name" },
                values: new object[] { new Guid("c7accea6-65f7-4260-9241-ec18cb4ca01c"), 0, true, null, "No Pay Leave" });

            migrationBuilder.CreateIndex(
                name: "IX_WeekWorkingDays_WorkingDaysId",
                table: "WeekWorkingDays",
                column: "WorkingDaysId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeekWorkingDays");

            migrationBuilder.DeleteData(
                table: "leaveType",
                keyColumn: "Id",
                keyValue: new Guid("c7accea6-65f7-4260-9241-ec18cb4ca01c"));

            migrationBuilder.AddColumn<string>(
                name: "Weekdays",
                table: "workingDays",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "leaveType",
                columns: new[] { "Id", "CountPerYear", "IsActive", "LeaveBalanceId", "Name" },
                values: new object[] { new Guid("df381250-5038-46ff-b035-f94b683cac69"), 0, true, null, "No Pay Leave" });
        }
    }
}
