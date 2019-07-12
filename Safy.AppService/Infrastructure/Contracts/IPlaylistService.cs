using Safy.AppService.Models.Playlists;
using System.Threading.Tasks;

namespace Safy.AppService.Infrastructure.Contracts
{
    public interface IPlaylistService
    {
        Task<Item> GetPlaylist(string token);
        Task<bool> AddTrackToPlaylist(string playlistId, string trackId, string token);
    }
}