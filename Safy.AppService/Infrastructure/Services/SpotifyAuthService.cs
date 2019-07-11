using Newtonsoft.Json;
using Safy.AppService.Infrastructure.Contracts;
using Safy.AppService.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Safy.AppService.Infrastructure.Services
{
    public class SpotifyAuthService : ISpotifyAuthService
    {
        private readonly string clientId = "785665304a7640f399d9aa949b51f331";
        private readonly string clientSecret = "aad96a15ccb94e648e7c9f05d573d96f";
        private readonly string spotifyAuthUri = "https://accounts.spotify.com/api/token";
        
        private string authorizationRequest => Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));

        public async Task<Token> GetSpotifyToken()
        {
            var args = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            };

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Basic {authorizationRequest}");
                var content = new FormUrlEncodedContent(args);

                var response = await client.PostAsync(spotifyAuthUri, content);
                var message = await response.Content.ReadAsStringAsync();

                var token = JsonConvert.DeserializeObject<Token>(message);
                return token;
            }
        }

        public async Task<Token> RefreshSpotifyToken(string refreshToken)
        {
            var args = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "refresh_token"),
                new KeyValuePair<string, string>("refresh_token", refreshToken)
            };

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Basic {authorizationRequest}");
                var content = new FormUrlEncodedContent(args);

                var response = await client.PostAsync(spotifyAuthUri, content);
                var message = await response.Content.ReadAsStringAsync();

                var token = JsonConvert.DeserializeObject<Token>(message);
                return token;
            }
        }
    }
}
