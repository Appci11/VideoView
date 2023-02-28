using System.Net.Http.Json;

namespace VideoView.Services.UsersService
{
    public class UsersService : IUsersService
    {
        const string resUrl = "https://firestore.googleapis.com/v1/";

        private readonly HttpClient _http;

        public UsersService(HttpClient http)
        {
            _http = http;
        }
        public async Task<bool> CheckIfExistsById(string id)
        {
            var response = await _http.GetAsync($"{resUrl}projects/rolka-videosmth/databases/(default)/documents/users/{id}");
            if(response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> AddUser(string id)
        {
            var response = await _http.PostAsJsonAsync($"{resUrl}projects/rolka-videosmth/databases/(default)/documents/users?documentId={id}", 
                new {fields = new { } });
            if(response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
