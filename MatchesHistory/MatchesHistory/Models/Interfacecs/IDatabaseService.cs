namespace MatchesHistory.Models.Interfacecs
{
    using MatchesHistory.Data.Entities;
    using System.Collections.Generic;

    interface IDatabaseService
    {
        void AddRangeJSONToDatabase(HashSet<Result> results);
        List<long> GetAllMatchesIds();
        PlayerPerformance CurrentPlayer(long accountId);
        void UpdatePlayerPerformance(PlayerPerformance player);
    }
}
