using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalApplication.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientDepartments_AspNetUsers_UserId1",
                table: "PatientDepartments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PatientDepartments");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "PatientDepartments",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_PatientDepartments_UserId1",
                table: "PatientDepartments",
                newName: "IX_PatientDepartments_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDepartments_AspNetUsers_OwnerId",
                table: "PatientDepartments",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientDepartments_AspNetUsers_OwnerId",
                table: "PatientDepartments");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "PatientDepartments",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_PatientDepartments_OwnerId",
                table: "PatientDepartments",
                newName: "IX_PatientDepartments_UserId1");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "PatientDepartments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDepartments_AspNetUsers_UserId1",
                table: "PatientDepartments",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
