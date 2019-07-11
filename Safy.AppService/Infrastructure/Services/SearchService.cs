using Newtonsoft.Json;
using Safy.AppService.Infrastructure.Contracts;
using Safy.AppService.Models.Request;
using Safy.AppService.Models.SearchResponse;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Safy.AppService.Infrastructure.Services
{
    public class SearchService : ISearchService
    {
        private readonly string spotifyEndpoint = "https://api.spotify.com/v1/";
        private readonly ISpotifyAuthService SpotifyAuthService;

        public SearchService(ISpotifyAuthService spotifyAuthService)
        {
            SpotifyAuthService = spotifyAuthService ?? throw new ArgumentNullException(nameof(spotifyAuthService));
        }

        public async Task<SearchResponse> Search(Search searchQuery)
        {
            string query;
            using (var content = new FormUrlEncodedContent(new Dictionary<string, string>()
            {
                ["q"] = searchQuery.Query,
                ["type"] = !string.IsNullOrEmpty(searchQuery.Type) ? searchQuery.Type : "track",
                //["market"] = searchQuery.Market,
                ["limit"] = !string.IsNullOrEmpty(searchQuery.Limit.ToString()) ? searchQuery.Limit.ToString() : "10",
                ["offset"] = searchQuery.OffSet.ToString(),
                ["inclue_external"] = !string.IsNullOrEmpty(searchQuery.IncludeExternal) ? searchQuery.IncludeExternal : "audio"
            }))
            {
                query = content.ReadAsStringAsync().Result;
            }

            var token = await SpotifyAuthService.GetSpotifyToken();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
                var response = await client.GetAsync(new Uri($"{spotifyEndpoint}search/?{query}"));
                var message = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<SearchResponse>(message);
            }
        }

        public void PlaySong()
        {
            throw new NotImplementedException();
        }

    }
}
