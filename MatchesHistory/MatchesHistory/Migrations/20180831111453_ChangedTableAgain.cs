using Microsoft.EntityFrameworkCore.Migrations;

namespace MatchesHistory.Migrations
{
    public partial class ChangedTableAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AccountId",
                table: "PlayersPerformance",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "PlayersPerformance");
        }
    }
}
