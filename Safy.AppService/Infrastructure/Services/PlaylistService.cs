using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Safy.AppService.Infrastructure.Contracts;
using Safy.AppService.Models.Playlists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Safy.AppService.Infrastructure.Services
{
    public class PlaylistService : IPlaylistService
    {
        public readonly ISpotifyAuthService SpotifyAuthService;
        private readonly string spotifyEndpoint = "https://api.spotify.com/v1/users/w825vocco1n962yd4cv9gnnza";

        public PlaylistService(ISpotifyAuthService spotifyAuthService)
        {
            SpotifyAuthService = spotifyAuthService ?? throw new ArgumentNullException(nameof(spotifyAuthService)); ;
        }

        public async Task<Item> GetPlaylist()
        {
            var token = await SpotifyAuthService.GetSpotifyToken();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
                var response = await client.GetAsync(new Uri($"{spotifyEndpoint}/playlists"));
                var message = await response.Content.ReadAsStringAsync();

                var playlists = JsonConvert.DeserializeObject<PlaylistResponse>(message);

                return playlists?.Items.FirstOrDefault();
            }
        }

        public async Task<bool> AddTrackToPlaylist(string playlistId, string trackId, string token)
        {
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var uris = new List<string> { $"spotify:track:{trackId}" };
                JObject body = new JObject
                {
                    {"uris", JArray.FromObject(uris)}
                };

                var content = new StringContent(JsonConvert.SerializeObject(body));
                content.Headers.ContentType.MediaType = "application/json";

                request.Content = content;
                request.Method = new HttpMethod("POST");

                request.RequestUri = new Uri($"https://api.spotify.com/v1/playlists/{playlistId}/tracks", UriKind.RelativeOrAbsolute);

                var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, CancellationToken.None).ConfigureAwait(false);

                return response.IsSuccessStatusCode;
            }

            //// Build URL
            //var url = $"{this.addressService}{this.Suffix}{this.serviceRoute}?{this.requestId}{requestId.Value.ToString()}&";

            //// Tenant
            //using (var client = new HttpClient())
            //using (var request = new HttpRequestMessage())
            //{
            //    // Create content
            //    var content = new StringContent(JsonConvert.SerializeObject(address));
            //    content.Headers.ContentType.MediaType = this.JsonMediaType;

            //    // Create request
            //    request.Content = content;
            //    request.Method = new HttpMethod("POST");

            //    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);

            //    // Response
            //    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, CancellationToken.None).ConfigureAwait(false);

            //    return await this.CreateSwaggerResponse(response);
            //}
        }
    }
}
