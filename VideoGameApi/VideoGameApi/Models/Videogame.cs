using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace VideoGameApi.Models
{
    public class Videogame
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public int Year { get; set; }

        [JsonProperty(PropertyName = "genre")]
        public string Genre { get; set; } = string.Empty;

    }
}
