using Newtonsoft.Json;

namespace Safy.AppService.Models.SearchResponse
{
    public class ExternalIds
    {
        [JsonProperty("isrc")]
        public string ISRC { get; set; }
    }
}
