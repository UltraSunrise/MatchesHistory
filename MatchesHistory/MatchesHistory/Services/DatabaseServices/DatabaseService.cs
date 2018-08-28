namespace MatchesHistory.Services.DatabaseServices
{
    using MatchesHistory.Data;
    using MatchesHistory.Data.Entities;
    using MatchesHistory.Models.Interfacecs;
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

                return matchesIds.FirstOrDefault();
            }
        }
    }
}
