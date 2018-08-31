namespace MatchesHistory.Services.PerfomanceCalculationServices
{
    using MatchesHistory.Models.Interfacecs;
    using MatchesHistory.Services.DatabaseServices;
    using System.Linq;

    public class CalculatePerformance : ICalculatePerformance
    {
        IDatabaseService dbServide = new DatabaseService();
        private readonly string PRIVATE_ACCOUNT = "4294967295";

        public void UpdatePlayerInfo(long accountId)
        {
            if (accountId.ToString() == PRIVATE_ACCOUNT)
                return;

            var results = dbServide.LastMonthResults();



            foreach (var result in results.Where(r => r.Players.Any(p => p.AccountId == accountId)))
            {

            }
        }
    }
}
