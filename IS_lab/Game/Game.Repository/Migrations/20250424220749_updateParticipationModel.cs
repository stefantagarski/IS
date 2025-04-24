using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game.Repository.Migrations
{
    /// <inheritdoc />
    public partial class updateParticipationModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Participations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participations_userId",
                table: "Participations",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participations_AspNetUsers_userId",
                table: "Participations",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participations_AspNetUsers_userId",
                table: "Participations");

            migrationBuilder.DropIndex(
                name: "IX_Participations_userId",
                table: "Participations");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Participations");
        }
    }
}
