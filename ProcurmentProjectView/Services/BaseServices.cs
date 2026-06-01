using ProcurmentProjectView.Config;
using ProcurmentProjectView.Interfaces;
using ProcurmentProjectView.Models;
using System.Net.Http.Headers;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace ProcurmentProjectView.Services
{
    public class BaseServices : IBaseApiService
    {
        private readonly HttpClient _client;
        public BaseServices(HttpClient client) 
        {
            _client = client;
        }
        public async Task<ResponseModel<T>> GetApiResponse<T>(string url, string token)
        { 
            if (!string.IsNullOrEmpty(token))
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            try
            {
                var response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadFromJsonAsync<ResponseModel<T>>();
                return result ?? new ResponseModel<T> { Message = "There are no Data found", Success = false };
            } catch (HttpRequestException)
            {
                return new ResponseModel<T> { Message = "Something went wrong, Please Try again later" ,Success = false };
            }
        }
        public async Task<ResponseModel<TResponse>> PostAsync<TRequest, TResponse>(string url, TRequest Data,string token)
        {
            try
            {
                if (!string.IsNullOrEmpty(token))
                {
                    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                HttpContent requestContent;

                // Check if the data is already pre-formatted HTTP content (like MultipartFormDataContent)
                if (Data is HttpContent customContent)
                {
                    requestContent = customContent;
                }
                else
                {
                    // Otherwise, automatically serialize the payload object to raw JSON
                    var serializeOptions = new System.Text.Json.JsonSerializerOptions
                    {
                        PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase
                    };
                    requestContent = JsonContent.Create(Data, options: serializeOptions);
                }

                var response = await _client.PostAsync(url, requestContent);

                // Read response using camelCase matching options
                var deserializeOptions = new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase
                };

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ResponseModel<TResponse>>(deserializeOptions);
                    return result ?? new ResponseModel<TResponse> { Message = "Action succeeded, but empty response data received.", Success = true };
                }
                else
                {
                    var errorMsg = await response.Content.ReadAsStringAsync();
                    return new ResponseModel<TResponse> { Message = $"Server Error: {errorMsg}", Success = false };
                }
            }
            catch (HttpRequestException e)
            {
                return new ResponseModel<TResponse> { Message = $"Server Error: {e.Message}", Success = false };
            }      
        }

        public async Task<ResponseModel<TResponse>> DeleteAsync<TRequest, TResponse>(string url, int id,string token)
        {
            try
            {
                if(!string.IsNullOrEmpty(token))
            }
            return new ResponseModel<TResponse> { Message = "" };
        }
    }
}
