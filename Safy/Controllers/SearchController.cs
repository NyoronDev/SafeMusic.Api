using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Safy.Api.Mappers;
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
        private readonly ISearchMapper searchMapper;

        public SearchController(ISpotifySearchService spotifySearchService, ISearchMapper searchMapper)
        {
            this.spotifySearchService = spotifySearchService;
            this.searchMapper = searchMapper;
        }

        // GET api/search/searchName
        [HttpGet("{searchName}")]
        public async Task<ActionResult<IEnumerable<Song>>> Get(string searchName)
        {
            var searchTrack = new Search { Type = "track", Limit = 10, Query = searchName };
            var searchResponse = await spotifySearchService.Search(searchTrack);

            var songList = this.searchMapper.MapToSongs(searchResponse);
            return Ok(songList);
        }
    }
}
