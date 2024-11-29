using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "leaveType",
                keyColumn: "Id",
                keyValue: new Guid("7213a7a3-29ef-451a-80fc-9ea04769dad0"));

            migrationBuilder.InsertData(
                table: "leaveType",
                columns: new[] { "Id", "CountPerYear", "IsActive", "LeaveBalanceId", "Name" },
                values: new object[] { new Guid("8ba2ad3d-27a4-4358-b769-8b1f7962b183"), 0, true, null, "No Pay Leave" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "leaveType",
                keyColumn: "Id",
                keyValue: new Guid("8ba2ad3d-27a4-4358-b769-8b1f7962b183"));

            migrationBuilder.InsertData(
                table: "leaveType",
                columns: new[] { "Id", "CountPerYear", "IsActive", "LeaveBalanceId", "Name" },
                values: new object[] { new Guid("7213a7a3-29ef-451a-80fc-9ea04769dad0"), 0, true, null, "No Pay Leave" });
        }
    }
}
