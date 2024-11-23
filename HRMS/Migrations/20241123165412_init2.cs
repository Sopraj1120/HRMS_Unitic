﻿using System;
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
            migrationBuilder.CreateTable(
                name: "leaveType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountPerYear = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leaveType", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    AvailableLeaveDays = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lane = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "aLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndexNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    School = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stream = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneralEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneralKnowledge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GIT = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_aLevels_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "experiances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_experiances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_experiances_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "higherLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stream = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Institute = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_higherLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_higherLevels_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndexNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    School = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tamil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Science = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Maths = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    English = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Basket1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Basket2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Basket3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_oLevels_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "accountDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIC_No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accountDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_accountDetail_users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "leaveResponse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ApproverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaveApplyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeaveDaysCount = table.Column<int>(type: "int", nullable: false),
                    LeaveTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UsersId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leaveResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_leaveResponse_leaveType_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "leaveType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_leaveResponse_users_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_leaveResponse_users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_leaveResponse_users_UsersId1",
                        column: x => x.UsersId1,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "userAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userAddresses_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "userExperiances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userExperiances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userExperiances_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userHigherStudies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stream = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Institute = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userHigherStudies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userHigherStudies_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userOLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndexNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    School = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tamil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Science = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Maths = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    English = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Basket1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Basket2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Basket3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userOLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userOLevels_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "hollyDays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeaveResponseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hollyDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hollyDays_leaveResponse_LeaveResponseId",
                        column: x => x.LeaveResponseId,
                        principalTable: "leaveResponse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "leaveApply",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeaveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LeaveStatus = table.Column<int>(type: "int", nullable: false),
                    leaveresId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leaveApply", x => x.Id);
                    table.ForeignKey(
                        name: "FK_leaveApply_leaveResponse_leaveresId",
                        column: x => x.leaveresId,
                        principalTable: "leaveResponse",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_leaveApply_leaveType_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "leaveType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_leaveApply_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accountDetail_UsersId",
                table: "accountDetail",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StudentId",
                table: "Address",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_aLevels_StudentId",
                table: "aLevels",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_experiances_StudentId",
                table: "experiances",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_higherLevels_StudentId",
                table: "higherLevels",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_hollyDays_LeaveResponseId",
                table: "hollyDays",
                column: "LeaveResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_leaveApply_leaveresId",
                table: "leaveApply",
                column: "leaveresId");

            migrationBuilder.CreateIndex(
                name: "IX_leaveApply_LeaveTypeId",
                table: "leaveApply",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_leaveApply_UserId",
                table: "leaveApply",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_leaveBalance_UserId",
                table: "leaveBalance",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_leaveResponse_ApproverId",
                table: "leaveResponse",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_leaveResponse_LeaveTypeId",
                table: "leaveResponse",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_leaveResponse_UsersId",
                table: "leaveResponse",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_leaveResponse_UsersId1",
                table: "leaveResponse",
                column: "UsersId1");

            migrationBuilder.CreateIndex(
                name: "IX_oLevels_StudentId",
                table: "oLevels",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_StudentId",
                table: "Parents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_userAddresses_UserId",
                table: "userAddresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_userALevels_userId",
                table: "userALevels",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_userExperiances_UserId",
                table: "userExperiances",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_userHigherStudies_UserId",
                table: "userHigherStudies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_userOLevels_UserId",
                table: "userOLevels",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accountDetail");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "aLevels");

            migrationBuilder.DropTable(
                name: "experiances");

            migrationBuilder.DropTable(
                name: "higherLevels");

            migrationBuilder.DropTable(
                name: "hollyDays");

            migrationBuilder.DropTable(
                name: "leaveApply");

            migrationBuilder.DropTable(
                name: "leaveBalance");

            migrationBuilder.DropTable(
                name: "oLevels");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "salary");

            migrationBuilder.DropTable(
                name: "userAddresses");

            migrationBuilder.DropTable(
                name: "userALevels");

            migrationBuilder.DropTable(
                name: "userExperiances");

            migrationBuilder.DropTable(
                name: "userHigherStudies");

            migrationBuilder.DropTable(
                name: "userOLevels");

            migrationBuilder.DropTable(
                name: "leaveResponse");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "leaveType");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
