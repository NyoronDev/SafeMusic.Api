using Safy.Api.Models;
using Safy.AppService.Models.SearchResponse;
using System.Collections.Generic;

namespace Safy.Api.Mappers
{
    public interface ISearchMapper
    {
        IEnumerable<Song> MapToSongs(SearchResponse searchResponse);
    }
}
