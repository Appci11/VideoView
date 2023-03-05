using Blazored.LocalStorage;
using Newtonsoft.Json;
using System.Net.Http.Json;
using VideoView.Models.Dto;

namespace VideoView.Services.AuthService
{
    public class AuthService : IAuthService
    {
        const string apiKey = "AIzaSyAtMYXiTMigdvDTG6B4V6MP768GL591NVo";
        const string baseUrl = "https://identitytoolkit.googleapis.com/v1/";

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
            
            var response = await _http.PostAsJsonAsync($"{baseUrl}accounts:signUp?key={apiKey}", new
            {
                email = authUserDto.email,
                password = authUserDto.password,
                returnSecureToken = true
            });
            if(response.IsSuccessStatusCode)
            {
                AuthResponseDto dto = JsonConvert.DeserializeObject<AuthResponseDto>(await response.Content.ReadAsStringAsync());
                await _localStorage.SetItemAsync("idToken", dto.idToken);
                await _localStorage.SetItemAsync<DateTime>("idTokenExpirationDate", DateTime.Now.AddSeconds(3600));
                await _localStorage.SetItemAsync("refreshToken", dto.refreshToken);
                await _localStorage.SetItemAsync("userId", dto.localId);
                await _authProvider.GetAuthenticationStateAsync();
                return dto;
            }
            return null;
        }
        public async Task<AuthResponseDto> Login(AuthUserDto authUserDto, bool stayLoggedIn)
        {
            var response = await _http.PostAsJsonAsync($"{baseUrl}accounts:signInWithPassword?key={apiKey}", new
            {
                email = authUserDto.email,
                password = authUserDto.password,
                returnSecureToken = true
            });
            if (response.IsSuccessStatusCode)
            {
                AuthResponseDto dto = JsonConvert.DeserializeObject<AuthResponseDto>(await response.Content.ReadAsStringAsync());
                await _localStorage.SetItemAsync("idToken", dto.idToken);
                await _localStorage.SetItemAsync<DateTime>("idTokenExpirationDate", DateTime.Now.AddSeconds(3600));
                await _localStorage.SetItemAsync("refreshToken", dto.refreshToken);
                await _localStorage.SetItemAsync("userId", dto.localId);
                await _localStorage.SetItemAsync<bool>("keepLoggedIn", stayLoggedIn);
                await _authProvider.GetAuthenticationStateAsync();
                return dto;
            }
            return null;
        }

        public async Task<bool> RefreshTokens()
        {
            // kazkas ne taip. Reiks prisijungt ner naujo.
            if(!await _localStorage.ContainKeyAsync("refreshToken") &&
                await _localStorage.ContainKeyAsync("idTokenExpirationDate"))
            {
                return false;
            }

            DateTime refreshDate = await _localStorage.GetItemAsync<DateTime>("idTokenExpirationDate");
            bool keepLoggedIn = await _localStorage.GetItemAsync<bool>("keepLoggedIn");
            if(!(refreshDate > DateTime.Now) && !keepLoggedIn)
            {
                return false;
            }
            const string url = "https://securetoken.googleapis.com/v1/";
            string token = await _localStorage.GetItemAsync<string>("refreshToken");
            _http.DefaultRequestHeaders.Clear();    //noring atsikratyt "Bearer" header'io
            var response = await _http.PostAsJsonAsync($"{url}token?key={apiKey}", new
            {
                grant_type = "refresh_token",
                refresh_token = token
            });
            if (response.IsSuccessStatusCode)
            {
                RefreshTokenInfoDto dto = JsonConvert.DeserializeObject<RefreshTokenInfoDto>(await response.Content.ReadAsStringAsync());
                await _localStorage.SetItemAsync("idToken", dto.id_token);
                await _localStorage.SetItemAsync<DateTime>("idTokenExpirationDate", DateTime.Now.AddSeconds(3600)); //galima atsargai kelias sec nuimt
                await _localStorage.SetItemAsync("refreshToken", dto.refresh_token);
                await _localStorage.SetItemAsync("userId", dto.user_id);
                await _authProvider.GetAuthenticationStateAsync();
                return true;
            }
            return false;
        }
    }
}
