using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Migrations
{
    /// <inheritdoc />
    public partial class addalevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "userALevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndexNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    School = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stream = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneralEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneralKnowledge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GIT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userALevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userALevels_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userALevels_userId",
                table: "userALevels",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userALevels");
        }
    }
}
