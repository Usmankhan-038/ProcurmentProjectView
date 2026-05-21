using ProcurmentProjectView.Config;
using ProcurmentProjectView.Interfaces;
using ProcurmentProjectView.Models;
using Microsoft.AspNetCore.Http;
namespace ProcurmentProjectView.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _client;

        public AuthService(HttpClient client) 
        {
            _client = client;
        }
        public async Task<ResponseModel<string>?> AuthenticationAsync(LoginViewModel login)
        {
            try
            {
                var loginApi = ApiEndPoints.Login();
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(login.UserEmail ?? ""), "userEmail");
                content.Add(new StringContent(login.Password ?? ""), "password");

                var response = await _client.PostAsync(loginApi, content);

                if (response.IsSuccessStatusCode)
                {
                    
                    return await response.Content.ReadFromJsonAsync<ResponseModel<string>>();
                }
                else if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    return new ResponseModel<string> { Message = error, Success = false };
                }
            }
            catch (HttpRequestException)
            {
                return new ResponseModel<string> { Message = "Something wents wrong, Please Try again latter", Success = false };
            }
            return null;
                
        }
    }
}
