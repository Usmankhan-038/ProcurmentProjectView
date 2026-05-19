using ProcurmentProjectView.Models;

namespace ProcurmentProjectView.Interfaces
{
    public interface IAuthService
    {
         Task<TokenResponseModel> AuthenticationAsync(LoginViewModel login);
    }
}
