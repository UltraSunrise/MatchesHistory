namespace MatchesHistory.Data.Entities
{
    using System.Collections.Generic;

    public class PlayerPerformance
    {
        public int Id { get; set; }
        public long AccountId { get; set; }
        public string Nickname { get; set; }
        public long GamesPlayedLastMonth { get; set; }
        public long GamesPlayedLastSixMonths { get; set; }
        public long Wins { get; set; }
        public long Losses { get; set; }
        public decimal WinRateLastMonth { get; set; }
        public decimal WinRateLastSixMonths { get; set; }
        public long MostPickedHeroLastMonth1 { get; set; }
        public long MostPickedHeroLastMonth2 { get; set; }
        public long MostPickedHeroLastMonth3 { get; set; }
        public long MostPickedHeroLastMonth4 { get; set; }
        public long MostPickedHeroLastMonth5 { get; set; }
        public long MostPickedHeroLastMonth6 { get; set; }
        public long MostPickedHeroLastSixMonths1 { get; set; }
        public long MostPickedHeroLastSixMonths2 { get; set; }
        public long MostPickedHeroLastSixMonths3 { get; set; }
        public long MostPickedHeroLastSixMonths4 { get; set; }
        public long MostPickedHeroLastSixMonths5 { get; set; }
        public long MostPickedHeroLastSixMonths6 { get; set; }
        public long HeroWithTheBestWinRate1 { get; set; }
        public long HeroWithTheBestWinRate2 { get; set; }
        public long HeroWithTheBestWinRate3 { get; set; }
        public List<PlayedHeroes> PlayedHeroes { get; set; } = new List<PlayedHeroes>();
    }
}
