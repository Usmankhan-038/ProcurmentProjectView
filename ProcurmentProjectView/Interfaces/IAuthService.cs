using ProcurmentProjectView.Models;

namespace ProcurmentProjectView.Interfaces
{
    public interface IAuthService
    {
         Task<ResponseModel<string>> AuthenticationAsync(LoginViewModel login);
    }
}
