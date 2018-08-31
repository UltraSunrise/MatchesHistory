using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MatchesHistory.Migrations
{
    public partial class AddedPlayedHeroes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayedHeroes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlayerPerformanceId = table.Column<int>(nullable: false),
                    HeroId = table.Column<long>(nullable: false),
                    StartDate = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayedHeroes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayedHeroes_PlayersPerformance_PlayerPerformanceId",
                        column: x => x.PlayerPerformanceId,
                        principalTable: "PlayersPerformance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayedHeroes_PlayerPerformanceId",
                table: "PlayedHeroes",
                column: "PlayerPerformanceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayedHeroes");
        }
    }
}
