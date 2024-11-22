using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Migrations
{
    /// <inheritdoc />
    public partial class apply : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_leaveApply_LeaveTypeId",
                table: "leaveApply");

            migrationBuilder.DropIndex(
                name: "IX_leaveApply_UserId",
                table: "leaveApply");

            migrationBuilder.CreateIndex(
                name: "IX_leaveApply_LeaveTypeId",
                table: "leaveApply",
                column: "LeaveTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_leaveApply_UserId",
                table: "leaveApply",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_leaveApply_LeaveTypeId",
                table: "leaveApply");

            migrationBuilder.DropIndex(
                name: "IX_leaveApply_UserId",
                table: "leaveApply");

            migrationBuilder.CreateIndex(
                name: "IX_leaveApply_LeaveTypeId",
                table: "leaveApply",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_leaveApply_UserId",
                table: "leaveApply",
                column: "UserId");
        }
    }
}
