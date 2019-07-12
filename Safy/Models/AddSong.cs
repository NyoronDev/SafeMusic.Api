using Newtonsoft.Json;

namespace Safy.Api.Models
{
    public class AddSong
    {
        [JsonProperty("track-id")]
        public string TrackId { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
