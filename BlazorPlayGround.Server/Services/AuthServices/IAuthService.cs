using BlazorPlayGround.Shared.DTOs;

namespace BlazorPlayGround.Server.Services.AuthServices
{
    public interface IAuthService
    {
        Task<List<UserLogin>> GetAllUser();
        Task<UserLogin> Register(UserLoginDto request);
        Task<string> Login(LoginDTo request);
        
    }
}
