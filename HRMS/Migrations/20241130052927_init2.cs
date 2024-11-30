using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_accountDetail_UsersId",
                table: "accountDetail");

            migrationBuilder.DeleteData(
                table: "leaveType",
                keyColumn: "Id",
                keyValue: new Guid("8ba2ad3d-27a4-4358-b769-8b1f7962b183"));

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "workingDays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Weekdays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workingDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_workingDays_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "leaveType",
                columns: new[] { "Id", "CountPerYear", "IsActive", "LeaveBalanceId", "Name" },
                values: new object[] { new Guid("df381250-5038-46ff-b035-f94b683cac69"), 0, true, null, "No Pay Leave" });

            migrationBuilder.CreateIndex(
                name: "IX_accountDetail_UsersId",
                table: "accountDetail",
                column: "UsersId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_workingDays_UserId",
                table: "workingDays",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "workingDays");

            migrationBuilder.DropIndex(
                name: "IX_accountDetail_UsersId",
                table: "accountDetail");

            migrationBuilder.DeleteData(
                table: "leaveType",
                keyColumn: "Id",
                keyValue: new Guid("df381250-5038-46ff-b035-f94b683cac69"));

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Students");

            migrationBuilder.InsertData(
                table: "leaveType",
                columns: new[] { "Id", "CountPerYear", "IsActive", "LeaveBalanceId", "Name" },
                values: new object[] { new Guid("8ba2ad3d-27a4-4358-b769-8b1f7962b183"), 0, true, null, "No Pay Leave" });

            migrationBuilder.CreateIndex(
                name: "IX_accountDetail_UsersId",
                table: "accountDetail",
                column: "UsersId");
        }
    }
}
