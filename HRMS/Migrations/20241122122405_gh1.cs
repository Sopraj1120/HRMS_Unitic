using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Migrations
{
    /// <inheritdoc />
    public partial class gh1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_leaveApply_leaveResponse_LeaveResponseId",
                table: "leaveApply");

            migrationBuilder.DropIndex(
                name: "IX_leaveApply_LeaveResponseId",
                table: "leaveApply");

            migrationBuilder.DropColumn(
                name: "LeaveResponseId",
                table: "leaveApply");

            migrationBuilder.CreateIndex(
                name: "IX_leaveApply_leaveresId",
                table: "leaveApply",
                column: "leaveresId");

            migrationBuilder.AddForeignKey(
                name: "FK_leaveApply_leaveResponse_leaveresId",
                table: "leaveApply",
                column: "leaveresId",
                principalTable: "leaveResponse",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_leaveApply_leaveResponse_leaveresId",
                table: "leaveApply");

            migrationBuilder.DropIndex(
                name: "IX_leaveApply_leaveresId",
                table: "leaveApply");

            migrationBuilder.AddColumn<Guid>(
                name: "LeaveResponseId",
                table: "leaveApply",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_leaveApply_LeaveResponseId",
                table: "leaveApply",
                column: "LeaveResponseId");

            migrationBuilder.AddForeignKey(
                name: "FK_leaveApply_leaveResponse_LeaveResponseId",
                table: "leaveApply",
                column: "LeaveResponseId",
                principalTable: "leaveResponse",
                principalColumn: "Id");
        }
    }
}
