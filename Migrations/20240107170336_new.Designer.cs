﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyRateApp2.Data;

#nullable disable

namespace MyRateApp2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240107170336_new")]
    partial class @new
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MyRateApp2.Models.Professor", b =>
                {
                    b.Property<long>("ProfId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ProfId"), 1L, 1);

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UniId")
                        .HasColumnType("int");

                    b.HasKey("ProfId");

                    b.HasIndex("UniId");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("MyRateApp2.Models.ProfessorRating", b =>
                {
                    b.Property<long>("ProfRateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ProfRateId"), 1L, 1);

                    b.Property<bool>("Attendance")
                        .HasColumnType("bit");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ForCredit")
                        .HasColumnType("bit");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<int>("LevelOfDifficulty")
                        .HasColumnType("int");

                    b.Property<int>("ProfGrade")
                        .HasColumnType("int");

                    b.Property<long?>("ProfId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Textbook")
                        .HasColumnType("bit");

                    b.Property<bool>("WouldTakeAgain")
                        .HasColumnType("bit");

                    b.HasKey("ProfRateId");

                    b.HasIndex("ProfId")
                        .IsUnique()
                        .HasFilter("[ProfId] IS NOT NULL");

                    b.ToTable("ProfessorRating");
                });

            modelBuilder.Entity("MyRateApp2.Models.University", b =>
                {
                    b.Property<int>("UniId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UniId"), 1L, 1);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UniId");

                    b.ToTable("University");
                });

            modelBuilder.Entity("MyRateApp2.Models.UniversityRating", b =>
                {
                    b.Property<int>("UniRatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UniRatingId"), 1L, 1);

                    b.Property<int>("Clubs")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Facilities")
                        .HasColumnType("int");

                    b.Property<int>("Food")
                        .HasColumnType("int");

                    b.Property<int>("Happiness")
                        .HasColumnType("int");

                    b.Property<int>("Internet")
                        .HasColumnType("int");

                    b.Property<int>("Location")
                        .HasColumnType("int");

                    b.Property<int>("Opportunity")
                        .HasColumnType("int");

                    b.Property<int>("Overall")
                        .HasColumnType("int");

                    b.Property<int>("Reputation")
                        .HasColumnType("int");

                    b.Property<int>("Safety")
                        .HasColumnType("int");

                    b.Property<int>("Social")
                        .HasColumnType("int");

                    b.Property<int?>("UniId")
                        .HasColumnType("int");

                    b.HasKey("UniRatingId");

                    b.HasIndex("UniId")
                        .IsUnique()
                        .HasFilter("[UniId] IS NOT NULL");

                    b.ToTable("UniversityRating");
                });

            modelBuilder.Entity("MyRateApp2.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("GraduationYear")
                        .HasColumnType("datetime2");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Password")
                        .HasColumnType("int");

                    b.Property<int>("ProfRateId")
                        .HasColumnType("int");

                    b.Property<string>("UniName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UniRatingId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MyRateApp2.Models.UserProfessorRating", b =>
                {
                    b.Property<long?>("ProfRateId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasIndex("ProfRateId");

                    b.HasIndex("UserId");

                    b.ToTable("UserProfessorRating");
                });

            modelBuilder.Entity("MyRateApp2.Models.UserUniversityRating", b =>
                {
                    b.Property<int?>("UniRatingId")
                        .HasColumnType("int");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasIndex("UniRatingId");

                    b.HasIndex("UserId");

                    b.ToTable("UserUniversityRating");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyRateApp2.Models.Professor", b =>
                {
                    b.HasOne("MyRateApp2.Models.University", "Uni")
                        .WithMany("Professors")
                        .HasForeignKey("UniId");

                    b.Navigation("Uni");
                });

            modelBuilder.Entity("MyRateApp2.Models.ProfessorRating", b =>
                {
                    b.HasOne("MyRateApp2.Models.Professor", "Prof")
                        .WithOne("ProfessorRating")
                        .HasForeignKey("MyRateApp2.Models.ProfessorRating", "ProfId");

                    b.Navigation("Prof");
                });

            modelBuilder.Entity("MyRateApp2.Models.UniversityRating", b =>
                {
                    b.HasOne("MyRateApp2.Models.University", "Uni")
                        .WithOne("UniversityRating")
                        .HasForeignKey("MyRateApp2.Models.UniversityRating", "UniId");

                    b.Navigation("Uni");
                });

            modelBuilder.Entity("MyRateApp2.Models.UserProfessorRating", b =>
                {
                    b.HasOne("MyRateApp2.Models.ProfessorRating", "ProfRate")
                        .WithMany()
                        .HasForeignKey("ProfRateId");

                    b.HasOne("MyRateApp2.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("ProfRate");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyRateApp2.Models.UserUniversityRating", b =>
                {
                    b.HasOne("MyRateApp2.Models.UniversityRating", "UniRating")
                        .WithMany()
                        .HasForeignKey("UniRatingId");

                    b.HasOne("MyRateApp2.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("UniRating");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyRateApp2.Models.Professor", b =>
                {
                    b.Navigation("ProfessorRating");
                });

            modelBuilder.Entity("MyRateApp2.Models.University", b =>
                {
                    b.Navigation("Professors");

                    b.Navigation("UniversityRating");
                });
#pragma warning restore 612, 618
        }
    }
}