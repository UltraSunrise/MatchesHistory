namespace MatchesHistory.Data.Entities
{
    public class PlayedHeroes
    {
        public long Id { get; set; }
        public int PlayerPerformanceId { get; set; }
        public PlayerPerformance PlayerPerformance { get; set; }
        public long HeroId { get; set; }
        public long StartDate { get; set; }
    }
}
