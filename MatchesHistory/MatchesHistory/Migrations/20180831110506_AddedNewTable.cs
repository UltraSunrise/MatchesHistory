using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MatchesHistory.Migrations
{
    public partial class AddedNewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayersPerformance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nickname = table.Column<string>(nullable: true),
                    GamesPlayedLastMonth = table.Column<long>(nullable: false),
                    GamesPlayedLastSixMonths = table.Column<long>(nullable: false),
                    WinRateLastMonth = table.Column<decimal>(nullable: false),
                    WinRateLastSixMonths = table.Column<decimal>(nullable: false),
                    MostPickedHeroLastMonth1 = table.Column<long>(nullable: false),
                    MostPickedHeroLastMonth2 = table.Column<long>(nullable: false),
                    MostPickedHeroLastMonth3 = table.Column<long>(nullable: false),
                    MostPickedHeroLastMonth4 = table.Column<long>(nullable: false),
                    MostPickedHeroLastMonth5 = table.Column<long>(nullable: false),
                    MostPickedHeroLastMonth6 = table.Column<long>(nullable: false),
                    MostPickedHeroLastSixMonths1 = table.Column<long>(nullable: false),
                    MostPickedHeroLastSixMonths2 = table.Column<long>(nullable: false),
                    MostPickedHeroLastSixMonths3 = table.Column<long>(nullable: false),
                    MostPickedHeroLastSixMonths4 = table.Column<long>(nullable: false),
                    MostPickedHeroLastSixMonths5 = table.Column<long>(nullable: false),
                    MostPickedHeroLastSixMonths6 = table.Column<long>(nullable: false),
                    HeroWithTheBestWinRate1 = table.Column<long>(nullable: false),
                    HeroWithTheBestWinRate2 = table.Column<long>(nullable: false),
                    HeroWithTheBestWinRate3 = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersPerformance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RadiantWin = table.Column<bool>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    PreGameDuration = table.Column<int>(nullable: false),
                    StartTime = table.Column<long>(nullable: false),
                    MatchId = table.Column<long>(nullable: false),
                    MatchSeqNumber = table.Column<long>(nullable: false),
                    TowerStatusRadiant = table.Column<int>(nullable: false),
                    TowerStatusDire = table.Column<int>(nullable: false),
                    BarracksStatusRadiant = table.Column<int>(nullable: false),
                    BarracksStatusDire = table.Column<int>(nullable: false),
                    Cluster = table.Column<int>(nullable: false),
                    FirstBloodTime = table.Column<int>(nullable: false),
                    LobbyType = table.Column<int>(nullable: false),
                    HumanPlayers = table.Column<int>(nullable: false),
                    LeagueId = table.Column<int>(nullable: false),
                    PositiveVotes = table.Column<int>(nullable: false),
                    NegativeVotes = table.Column<int>(nullable: false),
                    GameMode = table.Column<int>(nullable: false),
                    Flags = table.Column<int>(nullable: false),
                    Engine = table.Column<int>(nullable: false),
                    RadiantScore = table.Column<int>(nullable: false),
                    DireScore = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<long>(nullable: false),
                    PlayerSlot = table.Column<int>(nullable: false),
                    HeroId = table.Column<int>(nullable: false),
                    Item0 = table.Column<int>(nullable: false),
                    Item1 = table.Column<int>(nullable: false),
                    Item2 = table.Column<int>(nullable: false),
                    Item3 = table.Column<int>(nullable: false),
                    Item4 = table.Column<int>(nullable: false),
                    Item5 = table.Column<int>(nullable: false),
                    Backpack0 = table.Column<int>(nullable: false),
                    Backpack1 = table.Column<int>(nullable: false),
                    Backpack2 = table.Column<int>(nullable: false),
                    Kills = table.Column<int>(nullable: false),
                    Deaths = table.Column<int>(nullable: false),
                    Assists = table.Column<int>(nullable: false),
                    LeaverStatus = table.Column<int>(nullable: false),
                    LastHits = table.Column<int>(nullable: false),
                    Denies = table.Column<int>(nullable: false),
                    GoldPerMinute = table.Column<int>(nullable: false),
                    XPPerMinute = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    HeroDamage = table.Column<int>(nullable: false),
                    BuildingDamage = table.Column<int>(nullable: false),
                    HeroHealing = table.Column<int>(nullable: false),
                    Gold = table.Column<int>(nullable: false),
                    GoldSpent = table.Column<int>(nullable: false),
                    ScaledHeroDamage = table.Column<int>(nullable: false),
                    ScaledBuildingDamage = table.Column<int>(nullable: false),
                    ScaledHeroHealing = table.Column<int>(nullable: false),
                    ResultId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Results_ResultId",
                        column: x => x.ResultId,
                        principalTable: "Results",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AbilityId = table.Column<int>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abilities_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_PlayerId",
                table: "Abilities",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_ResultId",
                table: "Players",
                column: "ResultId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "PlayersPerformance");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Results");
        }
    }
}
