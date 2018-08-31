﻿namespace MatchesHistory.Models.Interfacecs
{
    using MatchesHistory.Data.Entities;
    using System.Collections.Generic;

    interface IDatabaseService
    {
        void AddJSONToDatabase(Result result);
        void AddRangeJSONToDatabase(HashSet<Result> results);
        long GetLastAddedMatch();
        List<long> GetAllMatchesIds();
        List<Result> LastMonthResults();
        PlayerPerformance CurrentPlayer(long accountId);
        void UpdatePlayerPerformance(PlayerPerformance player);
    }
}
