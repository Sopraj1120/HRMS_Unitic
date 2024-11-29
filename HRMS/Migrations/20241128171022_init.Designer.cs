﻿// <auto-generated />
using System;
using HRMS.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HRMS.Migrations
{
    [DbContext(typeof(HRMDBContext))]
    [Migration("20241128171022_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HRMS.Entities.ALevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GIT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GeneralEnglish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GeneralKnowledge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IndexNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("School")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stream")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Subject1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("aLevels");
                });

            modelBuilder.Entity("HRMS.Entities.AccountDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccountNumber")
                        .HasColumnType("int");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BranchName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsersEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UsersNIC_No")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsersName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsersPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UsersId");

                    b.ToTable("accountDetail");
                });

            modelBuilder.Entity("HRMS.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lane")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("HRMS.Entities.Experiance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("experiances");
                });

            modelBuilder.Entity("HRMS.Entities.HigherStudies", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Institute")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stream")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("higherLevels");
                });

            modelBuilder.Entity("HRMS.Entities.HollyDays", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LeaveRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LeaveRequestId");

                    b.ToTable("hollyDays");
                });

            modelBuilder.Entity("HRMS.Entities.LeaveBalance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CountPerYear")
                        .HasColumnType("int");

                    b.Property<Guid>("LeaveTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Leavebalance")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("leaveBalance");
                });

            modelBuilder.Entity("HRMS.Entities.LeaveRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ApplyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AproverId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AvailableLeaves")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LeaveDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReJoinDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("leaveCount")
                        .HasColumnType("int");

                    b.Property<Guid>("leaveTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<Guid>("usersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("leaveTypeId");

                    b.HasIndex("usersId");

                    b.ToTable("leaveRequest");
                });

            modelBuilder.Entity("HRMS.Entities.OLevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Basket1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Basket2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Basket3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("English")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("History")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IndexNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Maths")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Religion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("School")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Science")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Tamil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("oLevels");
                });

            modelBuilder.Entity("HRMS.Entities.Parents", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Job")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Parents");
                });

            modelBuilder.Entity("HRMS.Entities.Salary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Allowenss")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("BasicSalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Bonus")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Dedection")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("EPF")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Etf")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("LeaveTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("NetSalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("SalaryStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkingDays")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LeaveTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("salary");
                });

            modelBuilder.Entity("HRMS.Entities.Students", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaritalStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("HRMS.Entities.UserALevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GIT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GeneralEnglish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GeneralKnowledge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IndexNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("School")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stream")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("userALevels");
                });

            modelBuilder.Entity("HRMS.Entities.UserAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("userAddresses");
                });

            modelBuilder.Entity("HRMS.Entities.UserExperiance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("userExperiances");
                });

            modelBuilder.Entity("HRMS.Entities.UserHigherStudies", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Institute")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stream")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("userHigherStudies");
                });

            modelBuilder.Entity("HRMS.Entities.UserOLevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Basket1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Basket2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Basket3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("English")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("History")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IndexNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Maths")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Religion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("School")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Science")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tamil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("userOLevels");
                });

            modelBuilder.Entity("HRMS.Entities.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MerritalStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UsersId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("LeaveType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CountPerYear")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LeaveBalanceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LeaveBalanceId");

                    b.ToTable("leaveType");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8ba2ad3d-27a4-4358-b769-8b1f7962b183"),
                            CountPerYear = 0,
                            IsActive = true,
                            Name = "No Pay Leave"
                        });
                });

            modelBuilder.Entity("HRMS.Entities.ALevel", b =>
                {
                    b.HasOne("HRMS.Entities.Students", "Student")
                        .WithMany("ALs")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("HRMS.Entities.AccountDetail", b =>
                {
                    b.HasOne("HRMS.Entities.Users", "Users")
                        .WithMany("accountDetail")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("HRMS.Entities.Address", b =>
                {
                    b.HasOne("HRMS.Entities.Students", "Student")
                        .WithMany("Address")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("HRMS.Entities.Experiance", b =>
                {
                    b.HasOne("HRMS.Entities.Students", "Student")
                        .WithMany("Experiances")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("HRMS.Entities.HigherStudies", b =>
                {
                    b.HasOne("HRMS.Entities.Students", "Student")
                        .WithMany("HigherStudies")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("HRMS.Entities.HollyDays", b =>
                {
                    b.HasOne("HRMS.Entities.LeaveRequest", null)
                        .WithMany("HollyDays")
                        .HasForeignKey("LeaveRequestId");
                });

            modelBuilder.Entity("HRMS.Entities.LeaveBalance", b =>
                {
                    b.HasOne("HRMS.Entities.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HRMS.Entities.LeaveRequest", b =>
                {
                    b.HasOne("LeaveType", "leaveType")
                        .WithMany("LeaveRequest")
                        .HasForeignKey("leaveTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRMS.Entities.Users", "users")
                        .WithMany("LeaveRequests")
                        .HasForeignKey("usersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("leaveType");

                    b.Navigation("users");
                });

            modelBuilder.Entity("HRMS.Entities.OLevel", b =>
                {
                    b.HasOne("HRMS.Entities.Students", "Student")
                        .WithMany("OLs")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("HRMS.Entities.Parents", b =>
                {
                    b.HasOne("HRMS.Entities.Students", "Student")
                        .WithMany("Parents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("HRMS.Entities.Salary", b =>
                {
                    b.HasOne("LeaveType", "LeaveType")
                        .WithMany()
                        .HasForeignKey("LeaveTypeId");

                    b.HasOne("HRMS.Entities.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LeaveType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HRMS.Entities.UserALevel", b =>
                {
                    b.HasOne("HRMS.Entities.Users", "user")
                        .WithMany("userALevels")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("HRMS.Entities.UserAddress", b =>
                {
                    b.HasOne("HRMS.Entities.Users", "User")
                        .WithMany("userAddresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HRMS.Entities.UserExperiance", b =>
                {
                    b.HasOne("HRMS.Entities.Users", "User")
                        .WithMany("userExperiances")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HRMS.Entities.UserHigherStudies", b =>
                {
                    b.HasOne("HRMS.Entities.Users", "Users")
                        .WithMany("userHigherStudies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("HRMS.Entities.UserOLevel", b =>
                {
                    b.HasOne("HRMS.Entities.Users", "User")
                        .WithMany("userOLevels")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LeaveType", b =>
                {
                    b.HasOne("HRMS.Entities.LeaveBalance", null)
                        .WithMany("leaveTypes")
                        .HasForeignKey("LeaveBalanceId");
                });

            modelBuilder.Entity("HRMS.Entities.LeaveBalance", b =>
                {
                    b.Navigation("leaveTypes");
                });

            modelBuilder.Entity("HRMS.Entities.LeaveRequest", b =>
                {
                    b.Navigation("HollyDays");
                });

            modelBuilder.Entity("HRMS.Entities.Students", b =>
                {
                    b.Navigation("ALs");

                    b.Navigation("Address");

                    b.Navigation("Experiances");

                    b.Navigation("HigherStudies");

                    b.Navigation("OLs");

                    b.Navigation("Parents");
                });

            modelBuilder.Entity("HRMS.Entities.Users", b =>
                {
                    b.Navigation("LeaveRequests");

                    b.Navigation("accountDetail");

                    b.Navigation("userALevels");

                    b.Navigation("userAddresses");

                    b.Navigation("userExperiances");

                    b.Navigation("userHigherStudies");

                    b.Navigation("userOLevels");
                });

            modelBuilder.Entity("LeaveType", b =>
                {
                    b.Navigation("LeaveRequest");
                });
#pragma warning restore 612, 618
        }
    }
}
