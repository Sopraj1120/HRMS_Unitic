using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Migrations
{
    /// <inheritdoc />
    public partial class init555 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "leaveType",
                keyColumn: "Id",
                keyValue: new Guid("f3f84548-3232-422b-be0b-1904af8ce518"));

            migrationBuilder.InsertData(
                table: "leaveType",
                columns: new[] { "Id", "CountPerYear", "IsActive", "LeaveBalanceId", "Name" },
                values: new object[] { new Guid("fe7a68ab-9f1d-415f-933b-a67d52a2d264"), 0, true, null, "No Pay Leave" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "leaveType",
                keyColumn: "Id",
                keyValue: new Guid("fe7a68ab-9f1d-415f-933b-a67d52a2d264"));

            migrationBuilder.InsertData(
                table: "leaveType",
                columns: new[] { "Id", "CountPerYear", "IsActive", "LeaveBalanceId", "Name" },
                values: new object[] { new Guid("f3f84548-3232-422b-be0b-1904af8ce518"), 0, true, null, "No Pay Leave" });
        }
    }
}
