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
            migrationBuilder.AddColumn<Guid>(
                name: "LeaveBalanceId",
                table: "leaveType",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountPerYear",
                table: "leaveBalance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Leavebalance",
                table: "leaveBalance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_leaveType_LeaveBalanceId",
                table: "leaveType",
                column: "LeaveBalanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_leaveType_leaveBalance_LeaveBalanceId",
                table: "leaveType",
                column: "LeaveBalanceId",
                principalTable: "leaveBalance",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_leaveType_leaveBalance_LeaveBalanceId",
                table: "leaveType");

            migrationBuilder.DropIndex(
                name: "IX_leaveType_LeaveBalanceId",
                table: "leaveType");

            migrationBuilder.DropColumn(
                name: "LeaveBalanceId",
                table: "leaveType");

            migrationBuilder.DropColumn(
                name: "CountPerYear",
                table: "leaveBalance");

            migrationBuilder.DropColumn(
                name: "Leavebalance",
                table: "leaveBalance");
        }
    }
}
