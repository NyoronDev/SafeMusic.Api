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
        private readonly ISearchService searchService;
        private readonly ISearchMapper searchMapper;
        private readonly IPlaylistService playlistService;

        public SearchController(ISearchService searchService, ISearchMapper searchMapper, IPlaylistService playlistService)
        {
            this.searchService = searchService;
            this.searchMapper = searchMapper;
            this.playlistService = playlistService;
        }

        // GET api/search/searchName
        [HttpGet("{searchName}")]
        public async Task<ActionResult<IEnumerable<Song>>> Get(string searchName)
        {
            var searchTrack = new Search { Type = "track", Limit = 10, Query = searchName };
            var searchResponse = await searchService.Search(searchTrack);

            var songList = this.searchMapper.MapToSongs(searchResponse);
            return Ok(songList);
        }

        // POST api/search
        [HttpPost]
        public async Task<ActionResult> Post(AddSong addSong)
        {
            // var playlist = await this.playlistService.GetPlaylist(addSong.Token);
            await this.playlistService.AddTrackToPlaylist("3YuadZiUHqqrx2BJKqjKZr", addSong.TrackId, addSong.Token);

            return Ok();
        }
    }
}
