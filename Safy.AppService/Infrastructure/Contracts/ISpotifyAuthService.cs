using Safy.AppService.Models;
using System.Threading.Tasks;

namespace Safy.AppService.Infrastructure.Contracts
{
    public interface ISpotifyAuthService
    {
        Task<Token> GetSpotifyToken();
        Task<Token> RefreshSpotifyToken(string refreshToken);
    }
}
