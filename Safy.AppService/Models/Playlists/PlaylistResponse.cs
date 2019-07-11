using Newtonsoft.Json;
using System.Collections.Generic;

namespace Safy.AppService.Models.Playlists
{
    public class PlaylistResponse
    {       
        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }
}
