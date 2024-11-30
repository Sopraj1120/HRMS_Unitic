using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Migrations
{
    /// <inheritdoc />
    public partial class init6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentAttendances_Students_StudentsId",
                table: "studentAttendances");

            migrationBuilder.DropIndex(
                name: "IX_studentAttendances_StudentsId",
                table: "studentAttendances");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "studentAttendances");

            migrationBuilder.CreateIndex(
                name: "IX_studentAttendances_StudentId",
                table: "studentAttendances",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_studentAttendances_Students_StudentId",
                table: "studentAttendances",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentAttendances_Students_StudentId",
                table: "studentAttendances");

            migrationBuilder.DropIndex(
                name: "IX_studentAttendances_StudentId",
                table: "studentAttendances");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentsId",
                table: "studentAttendances",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_studentAttendances_StudentsId",
                table: "studentAttendances",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_studentAttendances_Students_StudentsId",
                table: "studentAttendances",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
