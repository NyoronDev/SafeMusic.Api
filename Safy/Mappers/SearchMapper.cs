using Safy.Api.Models;
using Safy.AppService.Models.SearchResponse;
using System.Collections.Generic;
using System.Linq;

namespace Safy.Api.Mappers
{
    public class SearchMapper : ISearchMapper
    {
        public IEnumerable<Song> MapToSongs(SearchResponse searchResponse)
        {
            var songList = new List<Song>();

            foreach (var track in searchResponse.Tracks.Items)
            {
                var artists = track.Artists.Select(i => i.Name).Aggregate((i, j) => i + string.Empty + j);
                var song = new Song { Name = track.Name, Id = track.Id, Album = track.Album.Name, Artist = artists, Image = track.Album.Images.FirstOrDefault().Url };

                songList.Add(song);
            }

            return songList;
        }
    }
}
