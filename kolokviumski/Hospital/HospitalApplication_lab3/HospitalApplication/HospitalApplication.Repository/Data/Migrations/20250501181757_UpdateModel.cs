using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalApplication.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "PatientDepartments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDepartments_OwnerId",
                table: "PatientDepartments",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDepartments_AspNetUsers_OwnerId",
                table: "PatientDepartments",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientDepartments_AspNetUsers_OwnerId",
                table: "PatientDepartments");

            migrationBuilder.DropIndex(
                name: "IX_PatientDepartments_OwnerId",
                table: "PatientDepartments");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "PatientDepartments");
        }
    }
}
