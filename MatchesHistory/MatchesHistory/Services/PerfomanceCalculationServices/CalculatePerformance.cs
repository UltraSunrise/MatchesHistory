namespace MatchesHistory.Services.PerfomanceCalculationServices
{
    using MatchesHistory.Data.Entities;
    using MatchesHistory.Models.Interfacecs;
    using MatchesHistory.Services.DatabaseServices;
    using System.Linq;

    public class CalculatePerformance : ICalculatePerformance
    {
        IDatabaseService dbService = new DatabaseService();
        private readonly string PRIVATE_ACCOUNT = "4294967295";

        public void UpdatePlayerInfo(long accountId)
        {
            if (accountId.ToString() == PRIVATE_ACCOUNT)
                return;

            var results = dbService.LastMonthResults();

            PlayerPerformance currentPlayer = dbService.CurrentPlayer(accountId) == null ? new PlayerPerformance() : dbService.CurrentPlayer(accountId);
            
            foreach (var result in results.Where(r => r.Players.Any(p => p.AccountId == accountId)))
            {
                Player player = result.Players.FirstOrDefault(p => p.AccountId == accountId);

                bool radiantWin = result.RadiantWin;

                bool isPlayerRadiant = result.Players.Take(5).FirstOrDefault(p => p.AccountId == accountId) != null;

                if ((radiantWin && isPlayerRadiant) || (!radiantWin && isPlayerRadiant))
                    currentPlayer.Wins += 1;
                else
                    currentPlayer.Losses += 1;

                currentPlayer.PlayedHeroes.Add(new PlayedHeroes()
                {
                    HeroId = player.HeroId,
                    StartDate = result.StartTime
                });

                currentPlayer.GamesPlayedLastMonth += 1;
                currentPlayer.GamesPlayedLastSixMonths += 1;
            }
        }
    }
}
