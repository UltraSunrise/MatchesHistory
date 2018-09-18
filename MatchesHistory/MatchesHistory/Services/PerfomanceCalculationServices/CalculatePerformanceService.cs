namespace MatchesHistory.Services.PerfomanceCalculationServices
{
    using MatchesHistory.Data.Entities;
    using MatchesHistory.Models.Interfacecs;
    using MatchesHistory.Services.DatabaseServices;
    using System.Linq;

    public class CalculatePerformanceService : ICalculatePerformanceService
    {
        private readonly IDatabaseService dbService = new DatabaseService();
        private readonly string PRIVATE_ACCOUNT = "4294967295";

        public void UpdatePlayerInfo(long accountId, Result result)
        {
            if (accountId.ToString() == PRIVATE_ACCOUNT)
                return;

            PlayerPerformance currentPlayerPerformance = dbService.CurrentPlayer(accountId);

            if (currentPlayerPerformance == null)
            {
                currentPlayerPerformance = new PlayerPerformance {AccountId = accountId};
            }

            Player currentPlayer = result.Players.FirstOrDefault(p => p.AccountId == accountId);

            bool radiantWin = result.RadiantWin;
            bool isPlayerRadiant = result.Players.Take(5).FirstOrDefault(p => p.AccountId == accountId) != null;

            bool isWin = false;

            if ((radiantWin && isPlayerRadiant) || (!radiantWin && isPlayerRadiant))
            {
                isWin = true;

                Win currentWin = new Win()
                {
                    AccountId = accountId,
                    HeroId = currentPlayer.HeroId,
                    StartTime = result.StartTime
                };

                dbService.AddWinToDatabase(currentWin);

                currentPlayerPerformance.Wins.Add(currentWin);
            }
            else
            {
                Loss currentLoss = new Loss()
                {
                    AccountId = accountId,
                    HeroId = currentPlayer.HeroId,
                    StartTime = result.StartTime
                };

                dbService.AddLossToDatabase(currentLoss);

                currentPlayerPerformance.Losses.Add(currentLoss);
            }

            PlayedHeroes playedHeroes = new PlayedHeroes()
            {
                AccountId = accountId,
                HeroId = currentPlayer.HeroId,
                IsWin = isWin,
                StartTime = result.StartTime
            };

            currentPlayerPerformance
                .PlayedHeroes
                .Add(playedHeroes);

            dbService.UpdatePlayerPerformance(currentPlayerPerformance);
        }
    }
}
