using ProcurmentProjectView.Models;

namespace ProcurmentProjectView.Interfaces
{
    public interface BaseApiService
    {
        Task<T> GetApiResponse<T>(string url);
        Task<TResponse> PostAsync<TResponse, TRequest>(string url, TRequest Data);

    }
}
