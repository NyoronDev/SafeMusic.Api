using Newtonsoft.Json;

namespace Safy.AppService.Models.SearchResponse
{
    public class ExternalUrls
    {
        [JsonProperty("spotify")]
        public string Spotify { get; set; }
    }
}
