using ProcurmentProjectView.Models;

namespace ProcurmentProjectView.Interfaces
{
    public interface IBaseApiService
    {
        public Task<ResponseModel<T>> GetApiResponse<T>(string url, string token);
        public Task<ResponseModel<TResponse>> PostAsync<TRequest,TResponse>(string url, TRequest Data, string token);

    }
}
