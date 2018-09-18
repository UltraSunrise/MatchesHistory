namespace MatchesHistory.Data.Entities
{
    public class Loss
    {
        public int Id { get; set; }
        public long AccountId { get; set; }
        public long HeroId { get; set; }
        public long StartTime { get; set; }

        public int PlayerPerformanceId { get; set; }
        public PlayerPerformance PlayerPerformance { get; set; }
    }
}