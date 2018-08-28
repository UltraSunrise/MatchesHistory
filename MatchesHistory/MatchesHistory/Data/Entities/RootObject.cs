namespace MatchesHistory.Data.Entities
{
    using Newtonsoft.Json;

    public class RootObject
    {
        [JsonProperty("result")]
        public Result Result { get; set; }
    }
}
