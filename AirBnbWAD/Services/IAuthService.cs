using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AirBnbWAD.Services
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterUserAsync(string username, string email, string password);
        Task<SignInResult> LoginUserAsync(string email, string password);
        Task LogoutAsync();
    }
}
