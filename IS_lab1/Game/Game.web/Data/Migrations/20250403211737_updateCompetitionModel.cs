using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game.web.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateCompetitionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Competitions",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Competitions");
        }
    }
}
