namespace MatchesHistory.Data.Entities
{
    using System.Collections.Generic;

    public class PlayerPerformance
    {
        public int Id { get; set; }
        public long AccountId { get; set; }
        public List<PlayedHeroes> PlayedHeroes { get; set; } = new List<PlayedHeroes>();
        public List<Win> Wins { get; set; } = new List<Win>();
        public List<Loss> Losses { get; set; } = new List<Loss>();
    }
}
