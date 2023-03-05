using VideoView.Models.Dto;

namespace VideoView.Services.AuthService
{
    //ateityje, kai netingesiu...
    public interface IAuthService
    {
        Task<AuthResponseDto> Register(AuthUserDto authUserDto);
        Task<AuthResponseDto> Login(AuthUserDto authUserDto, bool stayLoggedIn);
        Task<bool> RefreshTokens();
    }
}
