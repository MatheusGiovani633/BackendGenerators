using BackendGenerators.Models;

namespace BackendGenerators.Interfaces
{
    public interface IAuthService
    {
        Task<Usuario> RegisterAsync(string username, string password);
        Task<Usuario> LoginAsync(string username, string password);
        Task<Usuario> LogoutAsync(string username);
        Task<Usuario> RefreshTokenAsync(string username, string refreshToken);
    }

}