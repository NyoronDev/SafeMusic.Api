using Newtonsoft.Json;
using Safy.AppService.Infrastructure.Contracts;
using Safy.AppService.Models.Playlists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Safy.AppService.Infrastructure.Services
{
    public class PlaylistService : IPlaylistService
    {
        public readonly ISpotifyAuthService SpotifyAuthService;
        private readonly string spotifyEndpoint = "https://api.spotify.com/v1/";

        public PlaylistService(ISpotifyAuthService spotifyAuthService)
        {
            SpotifyAuthService = spotifyAuthService ?? throw new ArgumentNullException(nameof(spotifyAuthService)); ;
        }

        public async Task<Item> GetPlaylist()
        {
            var token = await this.SpotifyAuthService.GetSpotifyToken();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
                var response = await client.GetAsync(new Uri($"{spotifyEndpoint}me/playlists"));
                var message = await response.Content.ReadAsStringAsync();

                var playlists = JsonConvert.DeserializeObject<PlaylistResponse>(message);

                return playlists?.Items.FirstOrDefault();
            }
        }

        public async Task<bool> AddTrackToPlaylist(string playlistId, string trackId)
        {
            var token = await this.SpotifyAuthService.GetSpotifyToken();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);

                var parameters = new Dictionary<string, string> { { "spotify:track:", trackId } };

                var encodedContent = new FormUrlEncodedContent(parameters);

                var response = await client.PostAsync(new Uri($"{spotifyEndpoint}playlists/{playlistId}/tracks"), encodedContent);

                return response.IsSuccessStatusCode;
            }
        }
    }
}
