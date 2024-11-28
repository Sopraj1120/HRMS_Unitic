using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Migrations
{
    /// <inheritdoc />
    public partial class init558 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_salary_leaveType_LeaveTypeId",
                table: "salary");

            migrationBuilder.DeleteData(
                table: "leaveType",
                keyColumn: "Id",
                keyValue: new Guid("fe7a68ab-9f1d-415f-933b-a67d52a2d264"));

            migrationBuilder.AlterColumn<Guid>(
                name: "LeaveTypeId",
                table: "salary",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "leaveType",
                columns: new[] { "Id", "CountPerYear", "IsActive", "LeaveBalanceId", "Name" },
                values: new object[] { new Guid("7213a7a3-29ef-451a-80fc-9ea04769dad0"), 0, true, null, "No Pay Leave" });

            migrationBuilder.AddForeignKey(
                name: "FK_salary_leaveType_LeaveTypeId",
                table: "salary",
                column: "LeaveTypeId",
                principalTable: "leaveType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_salary_leaveType_LeaveTypeId",
                table: "salary");

            migrationBuilder.DeleteData(
                table: "leaveType",
                keyColumn: "Id",
                keyValue: new Guid("7213a7a3-29ef-451a-80fc-9ea04769dad0"));

            migrationBuilder.AlterColumn<Guid>(
                name: "LeaveTypeId",
                table: "salary",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "leaveType",
                columns: new[] { "Id", "CountPerYear", "IsActive", "LeaveBalanceId", "Name" },
                values: new object[] { new Guid("fe7a68ab-9f1d-415f-933b-a67d52a2d264"), 0, true, null, "No Pay Leave" });

            migrationBuilder.AddForeignKey(
                name: "FK_salary_leaveType_LeaveTypeId",
                table: "salary",
                column: "LeaveTypeId",
                principalTable: "leaveType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
