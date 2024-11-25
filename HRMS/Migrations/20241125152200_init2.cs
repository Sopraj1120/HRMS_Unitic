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
            migrationBuilder.DropForeignKey(
                name: "FK_leaveRequest_leaveType_leaveTypeId",
                table: "leaveRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_leaveRequest_users_usersId",
                table: "leaveRequest");

            migrationBuilder.AlterColumn<Guid>(
                name: "usersId",
                table: "leaveRequest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "leaveTypeId",
                table: "leaveRequest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_leaveRequest_leaveType_leaveTypeId",
                table: "leaveRequest",
                column: "leaveTypeId",
                principalTable: "leaveType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_leaveRequest_users_usersId",
                table: "leaveRequest",
                column: "usersId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_leaveRequest_leaveType_leaveTypeId",
                table: "leaveRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_leaveRequest_users_usersId",
                table: "leaveRequest");

            migrationBuilder.AlterColumn<Guid>(
                name: "usersId",
                table: "leaveRequest",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "leaveTypeId",
                table: "leaveRequest",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_leaveRequest_leaveType_leaveTypeId",
                table: "leaveRequest",
                column: "leaveTypeId",
                principalTable: "leaveType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_leaveRequest_users_usersId",
                table: "leaveRequest",
                column: "usersId",
                principalTable: "users",
                principalColumn: "Id");
        }
    }
}
