using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace VideoView
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _http;

        public CustomAuthStateProvider(ILocalStorageService localStorage, HttpClient http)
        {
            _localStorage = localStorage;
            _http = http;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //string token1 = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjE1YzJiNDBhYTJmMzIyNzk4NjY2YTZiMzMyYWFhMDNhNjc3MzAxOWIiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL3NlY3VyZXRva2VuLmdvb2dsZS5jb20vcm9sa2EtdmlkZW9zbXRoIiwiYXVkIjoicm9sa2EtdmlkZW9zbXRoIiwiYXV0aF90aW1lIjoxNjc3MzQwODEzLCJ1c2VyX2lkIjoiOVNJNFJ4aU1jWVljajQ5ZFVwYVFZSm9jY2VIMyIsInN1YiI6IjlTSTRSeGlNY1lZY2o0OWRVcGFRWUpvY2NlSDMiLCJpYXQiOjE2NzczNDA4MTMsImV4cCI6MTY3NzM0NDQxMywiZW1haWwiOiJwYXN0ZWxpc0BwYXN0LmNvbSIsImVtYWlsX3ZlcmlmaWVkIjpmYWxzZSwiZmlyZWJhc2UiOnsiaWRlbnRpdGllcyI6eyJlbWFpbCI6WyJwYXN0ZWxpc0BwYXN0LmNvbSJdfSwic2lnbl9pbl9wcm92aWRlciI6InBhc3N3b3JkIn19.COsr6ufAHrS9zzk8XcunDsno32usD-iqKJdMuPZudoWEnbbgVTMpPK2RkorXz3KFXnXYcqURassvAOOQD8vgXDcrVkh-abcXLIqxj-XUfxp54GsHpOsqNH_Kpa8xYir68-0bUoWlmfGuTdmphR4Caxsv-1bA0grUOoyEBjn64I2V3cr_av0P9YPuxpDhlTw0eptn2Evp-A3iXbSb9mczKXVP96wTG548aN0jykuwqzV5j6Iac-eaQ7StG4b7xLtcDaIdZId3nnpXxv4jgMAn71O9D2e4z_3IEDz5fVGYMfWsxnHDi-4X_KBXryOsGHJdHTxiofrnGSSuiVepJA0Iwg";
            //await _localStorage.SetItemAsync("idToken", token1);
            string token = await _localStorage.GetItemAsStringAsync("idToken");

            //var identity = new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwt");
            //var identity = new ClaimsIdentity();

            var identity = new ClaimsIdentity();
            _http.DefaultRequestHeaders.Authorization = null;

            if(!string.IsNullOrEmpty(token))
            {
                identity = new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwt");
                _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
            }    

            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }
    }
}
