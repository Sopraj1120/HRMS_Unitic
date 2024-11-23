using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Migrations
{
    /// <inheritdoc />
    public partial class initdb3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LeaveResponseId",
                table: "hollyDays",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_hollyDays_LeaveResponseId",
                table: "hollyDays",
                column: "LeaveResponseId");

            migrationBuilder.AddForeignKey(
                name: "FK_hollyDays_leaveResponse_LeaveResponseId",
                table: "hollyDays",
                column: "LeaveResponseId",
                principalTable: "leaveResponse",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hollyDays_leaveResponse_LeaveResponseId",
                table: "hollyDays");

            migrationBuilder.DropIndex(
                name: "IX_hollyDays_LeaveResponseId",
                table: "hollyDays");

            migrationBuilder.DropColumn(
                name: "LeaveResponseId",
                table: "hollyDays");
        }
    }
}
