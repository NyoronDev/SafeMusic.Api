using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Safy.AppService.Infrastructure.Contracts;
using Safy.AppService.Infrastructure.Services;

namespace Safy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly ISearchService SearchService;
        public readonly IPlaylistService PlaylistService;

        public ValuesController(ISearchService searchService, IPlaylistService playlistService)
        {
            SearchService = searchService;
            PlaylistService = playlistService;
        }

        // GET api/values
        [HttpGet]
        public async Task Get()
        {
            var playlist = PlaylistService.GetPlaylist();

            var result = await SearchService.Search(
            new AppService.Models.Request.Search
            {
                Query = "love in elevator",
                Limit = 10,
                Type = "track"
            });


        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
