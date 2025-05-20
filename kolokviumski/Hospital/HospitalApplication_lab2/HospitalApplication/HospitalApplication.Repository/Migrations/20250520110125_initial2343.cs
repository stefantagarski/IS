using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalApplication.Repository.Migrations
{
    /// <inheritdoc />
    public partial class initial2343 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientDepartments_AspNetUsers_OwnerId1",
                table: "PatientDepartments");

            migrationBuilder.RenameColumn(
                name: "OwnerId1",
                table: "PatientDepartments",
                newName: "UserId1");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "PatientDepartments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PatientDepartments_OwnerId1",
                table: "PatientDepartments",
                newName: "IX_PatientDepartments_UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDepartments_AspNetUsers_UserId1",
                table: "PatientDepartments",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientDepartments_AspNetUsers_UserId1",
                table: "PatientDepartments");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "PatientDepartments",
                newName: "OwnerId1");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PatientDepartments",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_PatientDepartments_UserId1",
                table: "PatientDepartments",
                newName: "IX_PatientDepartments_OwnerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDepartments_AspNetUsers_OwnerId1",
                table: "PatientDepartments",
                column: "OwnerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
