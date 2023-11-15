using BackEndAPI.Models;

namespace BackEndAPI.src.Base.Contracts.Service
{
    public interface IAuthService
    {
        Task<AuthResponse> Auth(AuthRequest auth);
    }
}