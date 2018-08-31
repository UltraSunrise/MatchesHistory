namespace MatchesHistory.Services.DatabaseServices
{
    using MatchesHistory.Data;
    using MatchesHistory.Data.Entities;
    using MatchesHistory.Models.Interfacecs;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DatabaseService : IDatabaseService
    {
        public void AddJSONToDatabase(Result result)
        {
            using (MatchesHistoryDbContext db = new MatchesHistoryDbContext())
            {
                db
                    .Results
                    .Add(result);

                db.SaveChanges();
            }
        }

        public void AddRangeJSONToDatabase(HashSet<Result> results)
        {
            using (MatchesHistoryDbContext db = new MatchesHistoryDbContext())
            {
                db
                    .Results
                    .AddRange(results);

                db.SaveChanges();
            }
        }

        public long GetLastAddedMatch()
        {
            using (MatchesHistoryDbContext db = new MatchesHistoryDbContext())
            {
                var results = db.Results;
                var matchesIds = new List<long>();

                foreach (var result in results)
                {
                    matchesIds.Add(result.MatchId);
                }
                matchesIds.Sort();

                return matchesIds.LastOrDefault();
            }
        }

        public List<long> GetAllMatchesIds()
        {
            using (MatchesHistoryDbContext db = new MatchesHistoryDbContext())
            {
                List<long> allMatchesIds = new List<long>();

                foreach (var result in db.Results)
                {
                    allMatchesIds.Add(result.MatchId);
                }

                return allMatchesIds;
            }
        }

        public List<Result> LastMonthResults()
        {
            using (MatchesHistoryDbContext db = new MatchesHistoryDbContext())
            {
                List<Result> results = new List<Result>();

                long startTime = DateTime.Now.Millisecond;

                results = db
                            .Results
                            .Where(r => r.StartTime > startTime)
                            .Include(r => r.Players)
                            .ToList();

                return results;
            }
        }

        public PlayerPerformance CurrentPlayer(long accountId)
        {
            using (MatchesHistoryDbContext db = new MatchesHistoryDbContext())
            {
                return db
                        .PlayersPerformance
                        .FirstOrDefault(pp => pp.AccountId == accountId);
            }
        }

        public void UpdatePlayerPerformance(PlayerPerformance player)
        {
            using (MatchesHistoryDbContext db = new MatchesHistoryDbContext())
            {
                if (db.PlayersPerformance.FirstOrDefault(p => p.AccountId == player.AccountId) == null)
                {
                    db.PlayersPerformance.Add(player);
                }
                else
                {
                    var entity = db.PlayersPerformance.FirstOrDefault(p => p.AccountId == player.AccountId);

                    db.Entry(entity).CurrentValues.SetValues(player);
                }
                
                db.SaveChanges();
            }
        }
    }
}
