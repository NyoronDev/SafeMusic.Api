using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Safy.AppService.Models.Playlists
{
    public class Item
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("href")]
        public string Href { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}
