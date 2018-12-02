using Microsoft.EntityFrameworkCore.Migrations;

namespace MatchesHistory.Migrations
{
    public partial class ChangedHeroTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HeroId",
                table: "Heroes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeroId",
                table: "Heroes");
        }
    }
}
