using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game.Repository.Migrations
{
    /// <inheritdoc />
    public partial class LAB3updateNameOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participations_AspNetUsers_UserId",
                table: "Participations");

            migrationBuilder.DropIndex(
                name: "IX_Participations_UserId",
                table: "Participations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Participations");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Participations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participations_OwnerId",
                table: "Participations",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participations_AspNetUsers_OwnerId",
                table: "Participations",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participations_AspNetUsers_OwnerId",
                table: "Participations");

            migrationBuilder.DropIndex(
                name: "IX_Participations_OwnerId",
                table: "Participations");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Participations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Participations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participations_UserId",
                table: "Participations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participations_AspNetUsers_UserId",
                table: "Participations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
