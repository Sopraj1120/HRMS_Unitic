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
            migrationBuilder.DropColumn(
                name: "AvailableLeaveDays",
                table: "users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "accountDetail");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "accountDetail",
                newName: "UsersPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "NIC_No",
                table: "accountDetail",
                newName: "UsersName");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "accountDetail",
                newName: "UsersNIC_No");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "accountDetail",
                newName: "UsersEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsersPhoneNumber",
                table: "accountDetail",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "UsersName",
                table: "accountDetail",
                newName: "NIC_No");

            migrationBuilder.RenameColumn(
                name: "UsersNIC_No",
                table: "accountDetail",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "UsersEmail",
                table: "accountDetail",
                newName: "Email");

            migrationBuilder.AddColumn<int>(
                name: "AvailableLeaveDays",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "accountDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
