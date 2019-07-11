using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Safy.Api.Models;
using Safy.AppService.Infrastructure.Contracts;
using Safy.AppService.Models.Request;

namespace Safy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISpotifySearchService spotifySearchService;

        public SearchController(ISpotifySearchService spotifySearchService)
        {
            this.spotifySearchService = spotifySearchService;
        }

        // GET api/search/searchName
        [HttpGet("{searchName}")]
        public async Task<ActionResult<IEnumerable<Song>>> Get(string searchName)
        {
            var searchTrack = new Search { Type = "track", Limit = 10, Query = searchName };
            var searchResponse = await spotifySearchService.Search(searchTrack);

            var search1 = new Song { Artist = "Artist1", Id = "Id1", Image = "Image1", Name = "Track1" };
            var search2 = new Song { Artist = "Artist2", Id = "Id2", Image = "Image2", Name = "Track2" };
            var search3 = new Song { Artist = "Artist3", Id = "Id3", Image = "Image3", Name = "Track3" };
            return new List<Song> { search1, search2, search3 };
        }
    }
}
