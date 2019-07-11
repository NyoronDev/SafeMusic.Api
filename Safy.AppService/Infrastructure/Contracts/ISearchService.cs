using Safy.AppService.Models.Request;
using Safy.AppService.Models.SearchResponse;
using System.Threading.Tasks;

namespace Safy.AppService.Infrastructure.Contracts
{
    public interface ISearchService
    {
        Task<SearchResponse> Search(Search searchQuery);
    }
}
