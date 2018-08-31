namespace MatchesHistory.Data.JSONParsers.LastGamesParsers
{
    using Newtonsoft.Json;

    public class ResultLastGames
    {
        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("num_results")]
        public long NumResults { get; set; }

        [JsonProperty("total_results")]
        public long TotalResults { get; set; }

        [JsonProperty("results_remaining")]
        public long ResultsRemaining { get; set; }

        [JsonProperty("matches")]
        public Match[] Matches { get; set; }
    }
}
