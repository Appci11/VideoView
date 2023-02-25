using Blazored.LocalStorage;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;
using VideoView.Models.Dto;

namespace VideoView.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authProvider;

        public AuthService(HttpClient http, ILocalStorageService localStorage, AuthenticationStateProvider authProvider)
        {
            _http = http;
            _localStorage = localStorage;
            _authProvider = authProvider;
        }

        public async Task<AuthResponseDto> Register(AuthUserDto authUserDto)
        {
            const string key = "AIzaSyAtMYXiTMigdvDTG6B4V6MP768GL591NVo";
            var response = await _http.PostAsJsonAsync($"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={key}", new
            {
                email = authUserDto.email,
                password = authUserDto.password,
                returnSecureToken = true
            });
            if(response.IsSuccessStatusCode)
            {
                AuthResponseDto dto = JsonConvert.DeserializeObject<AuthResponseDto>(await response.Content.ReadAsStringAsync());
                await _localStorage.SetItemAsync("idToken", dto.idToken);
                await _authProvider.GetAuthenticationStateAsync();
                return dto;
            }
            return null;
        }
        public async Task<AuthResponseDto> Login(AuthUserDto authUserDto)
        {
            const string key = "AIzaSyAtMYXiTMigdvDTG6B4V6MP768GL591NVo";
            var response = await _http.PostAsJsonAsync($"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={key}", new
            {
                email = authUserDto.email,
                password = authUserDto.password,
                returnSecureToken = true
            });
            if (response.IsSuccessStatusCode)
            {
                AuthResponseDto dto = JsonConvert.DeserializeObject<AuthResponseDto>(await response.Content.ReadAsStringAsync());
                await _localStorage.SetItemAsync("idToken", dto.idToken);
                await _authProvider.GetAuthenticationStateAsync();
                return dto;
            }
            return null;
        }
    }
}
