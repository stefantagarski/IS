using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalApplication.Repository.Migrations
{
    /// <inheritdoc />
    public partial class lab22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "PatientDepartments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "OwnerId1",
                table: "PatientDepartments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientDepartments_OwnerId1",
                table: "PatientDepartments",
                column: "OwnerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDepartments_AspNetUsers_OwnerId1",
                table: "PatientDepartments",
                column: "OwnerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientDepartments_AspNetUsers_OwnerId1",
                table: "PatientDepartments");

            migrationBuilder.DropIndex(
                name: "IX_PatientDepartments_OwnerId1",
                table: "PatientDepartments");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "PatientDepartments");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "PatientDepartments");
        }
    }
}
