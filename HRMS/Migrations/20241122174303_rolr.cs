using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Migrations
{
    /// <inheritdoc />
    public partial class rolr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_leaveResponse_LeaveTypeId",
                table: "leaveResponse");

            migrationBuilder.DropColumn(
                name: "LeaveResponceId",
                table: "leaveType");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "leaveResponse");

            migrationBuilder.CreateIndex(
                name: "IX_leaveResponse_ApproverId",
                table: "leaveResponse",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_leaveResponse_LeaveTypeId",
                table: "leaveResponse",
                column: "LeaveTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_leaveResponse_users_ApproverId",
                table: "leaveResponse",
                column: "ApproverId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_leaveResponse_users_ApproverId",
                table: "leaveResponse");

            migrationBuilder.DropIndex(
                name: "IX_leaveResponse_ApproverId",
                table: "leaveResponse");

            migrationBuilder.DropIndex(
                name: "IX_leaveResponse_LeaveTypeId",
                table: "leaveResponse");

            migrationBuilder.AddColumn<Guid>(
                name: "LeaveResponceId",
                table: "leaveType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "leaveResponse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_leaveResponse_LeaveTypeId",
                table: "leaveResponse",
                column: "LeaveTypeId",
                unique: true);
        }
    }
}
