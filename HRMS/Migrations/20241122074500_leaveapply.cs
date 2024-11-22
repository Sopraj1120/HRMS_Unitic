using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Migrations
{
    /// <inheritdoc />
    public partial class leaveapply : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LeaveBalanceId",
                table: "leaveType",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "leaveBalance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeaveTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leaveBalance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_leaveBalance_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "salary",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BasicSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Detection = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Bonas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EPF = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Etf = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Allowenss = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WorkingDasy = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salary", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_leaveType_LeaveBalanceId",
                table: "leaveType",
                column: "LeaveBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_leaveBalance_UserId",
                table: "leaveBalance",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_leaveType_leaveBalance_LeaveBalanceId",
                table: "leaveType",
                column: "LeaveBalanceId",
                principalTable: "leaveBalance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_leaveType_leaveBalance_LeaveBalanceId",
                table: "leaveType");

            migrationBuilder.DropTable(
                name: "leaveBalance");

            migrationBuilder.DropTable(
                name: "salary");

            migrationBuilder.DropIndex(
                name: "IX_leaveType_LeaveBalanceId",
                table: "leaveType");

            migrationBuilder.DropColumn(
                name: "LeaveBalanceId",
                table: "leaveType");
        }
    }
}
