using Infra.Dtos;
using Infra.Enum;
using Infra.Models;

namespace Infra.Services.Interfaces
{
    public interface HttpClientService
    {
        Task<List<Response>> GetResponsesAsync();
        Task DownloadPdfAsync(OpposerTask opposer, Action<string> action);
        Task GetOpposersAsync(List<OpposerTask> opposersTasks, Action action = null);
        Task<ResponseDto?> GetResponseByFineNumberAsync(string fineNumber);
        Task<bool> GetPdfByFineNumberAsync(OpposerTask opposer);
        Task<string> InsertResponseAsync(List<OpposerTask> opposersTasks, DecisionType decisionType, OpposerTask opposer, string notes, Action action);
        Task<string> LoginAsync(string userName, string password, Action action);
        Task<string> UpdateResponseAsync(List<OpposerTask> opposersTasks, DecisionType decisionType, OpposerTask opposer, string notes, Action action);
    }
}