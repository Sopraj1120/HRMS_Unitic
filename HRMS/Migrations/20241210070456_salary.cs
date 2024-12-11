using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Migrations
{
    /// <inheritdoc />
    public partial class salary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dedection",
                table: "salary",
                newName: "Deduction");

            migrationBuilder.RenameColumn(
                name: "Allowenss",
                table: "salary",
                newName: "Allowances");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Deduction",
                table: "salary",
                newName: "Dedection");

            migrationBuilder.RenameColumn(
                name: "Allowances",
                table: "salary",
                newName: "Allowenss");
        }
    }
}
