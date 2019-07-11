using Newtonsoft.Json;
using System;

namespace Safy.AppService.Models
{
    public class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public double ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsExpired => CreateDate.Add(TimeSpan.FromSeconds(ExpiresIn)) <= DateTime.UtcNow;

        public bool HasError => Error != null;

        public Token()
        {
            this.CreateDate = DateTime.UtcNow;
        }
    }
}
