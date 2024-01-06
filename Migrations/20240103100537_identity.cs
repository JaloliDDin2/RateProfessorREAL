using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyRateApp2.Migrations
{
    public partial class identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfessorRating_User_UserId",
                table: "UserProfessorRating");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUniversityRating_User_UserId",
                table: "UserUniversityRating");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_UserUniversityRating_UserId",
                table: "UserUniversityRating");

            migrationBuilder.DropIndex(
                name: "IX_UserProfessorRating_UserId",
                table: "UserProfessorRating");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserUniversityRating",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserProfessorRating",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "GraduationYear",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Lname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Password",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfRateId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UniName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UniRatingId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_UserUniversityRating_UserId1",
                table: "UserUniversityRating",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfessorRating_UserId1",
                table: "UserProfessorRating",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfessorRating_AspNetUsers_UserId1",
                table: "UserProfessorRating",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserUniversityRating_AspNetUsers_UserId1",
                table: "UserUniversityRating",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfessorRating_AspNetUsers_UserId1",
                table: "UserProfessorRating");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUniversityRating_AspNetUsers_UserId1",
                table: "UserUniversityRating");

            migrationBuilder.DropIndex(
                name: "IX_UserUniversityRating_UserId1",
                table: "UserUniversityRating");

            migrationBuilder.DropIndex(
                name: "IX_UserProfessorRating_UserId1",
                table: "UserProfessorRating");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserUniversityRating");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserProfessorRating");

            migrationBuilder.DropColumn(
                name: "Fname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GraduationYear",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Lname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfRateId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UniName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UniRatingId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GraduationYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<int>(type: "int", nullable: false),
                    ProfRateId = table.Column<int>(type: "int", nullable: false),
                    UniName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniRatingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserUniversityRating_UserId",
                table: "UserUniversityRating",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfessorRating_UserId",
                table: "UserProfessorRating",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfessorRating_User_UserId",
                table: "UserProfessorRating",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserUniversityRating_User_UserId",
                table: "UserUniversityRating",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");
        }
    }
}
