using BlazorPlayGround.Shared.DTOs;

namespace BlazorPlayGround.Client.Services.AuthServices
{
    public interface IClientAuthService
    {
        Token token { get; set; }
        List<UserLogin> users { get; set; }
        Task<List<UserLogin>> GetAllUser();
        Task Register(UserLoginDto request);
        Task<string> Login(LoginDTo request);
        
    }
}
