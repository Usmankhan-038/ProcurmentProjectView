using ProcurmentProjectView.Config;
using ProcurmentProjectView.Interfaces;
using ProcurmentProjectView.Models;

namespace ProcurmentProjectView.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _client;

        public AuthService(HttpClient client) 
        {
            _client = client;
        }
        public async Task<TokenResponseModel?> AuthenticationAsync(LoginViewModel login)
        {
            var loginApi = ApiEndPoints.Login();
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(login.UserEmail ?? ""), "userEmail");
            content.Add(new StringContent(login.Password?? ""), "password");

            var response = await _client.PostAsync(loginApi, content);
            
            if(response.IsSuccessStatusCode)
            {
                
                return await response.Content.ReadFromJsonAsync<TokenResponseModel>();
            } 
            else if(!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                return new TokenResponseModel { Message = error, Success = false };
            }
            return null;
                
        }
    }
}
