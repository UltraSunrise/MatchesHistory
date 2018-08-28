namespace MatchesHistory.Data.Entities
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class Ability
    {
        [Key]
        public int Id { get; set; }
        [JsonProperty("ability")]
        public int AbilityId { get; set; }
        [JsonProperty("time")]
        public int Time { get; set; }
        [JsonProperty("level")]
        public int Level { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
