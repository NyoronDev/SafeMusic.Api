using Newtonsoft.Json;

namespace Safy.AppService.Models.SearchResponse
{
    public class SearchResponse
    {
        [JsonProperty("tracks")]
        public Tracks Tracks { get; set; }
    }
}
