namespace MatchesHistory.Data.JSONParsers.LastGamesParsers
{
    using Newtonsoft.Json;

    public class LastGamesRootObject
    {
        [JsonProperty("result")]
        public ResultLastGames Result { get; set; }
    }
}
