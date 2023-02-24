using Newtonsoft.Json;
using System.Net.Http.Json;
using VideoView.Models.Cat;

namespace VideoView.Services.CatsService
{
    public class CatsService : ICatsService
    {
        private readonly HttpClient _http;

        public List<Cat> Cats { get; set; }

        public CatsService(HttpClient http)
        {
            _http = http;
        }

        public async Task GetAllCats()
        {
            var jsonResponse = await _http.GetStringAsync("https://firestore.googleapis.com/v1/projects/rolka-videosmth/databases/(default)/documents/cats");
            CatDocuments catDocs = JsonConvert.DeserializeObject<CatDocuments>(jsonResponse);
            Cats = catDocs.documents;
        }

        public async Task<Cat> GetCatById(string id)
        {
            //var jsonResponse = await _http.GetStringAsync($"https://firestore.googleapis.com/v1/projects/rolka-videosmth/databases/(default)/documents/cats/{id}");
            //Cat cat = JsonConvert.DeserializeObject<Cat>(jsonResponse);
            Cat cat = await _http.GetFromJsonAsync<Cat>($"https://firestore.googleapis.com/v1/projects/rolka-videosmth/databases/(default)/documents/cats/{id}");
            return cat;
        }

        public async Task AddCat(Cat cat)
        {
            var result = await _http.PostAsJsonAsync($"https://firestore.googleapis.com/v1/projects/rolka-videosmth/databases/(default)/documents/cats", new { fields = cat.fields });
        }

        public async Task UpdateCat(Cat cat)
        {
            string id = cat.name.Split('/').Last();
            await _http.PatchAsJsonAsync($"https://firestore.googleapis.com/v1/projects/rolka-videosmth/databases/(default)/documents/cats/{id}", new { fields = cat.fields });
        }

        public async Task DeleteCat(string id)
        {
            await _http.DeleteAsync($"https://firestore.googleapis.com/v1/projects/rolka-videosmth/databases/(default)/documents/cats/{id}");        
        }


    }
}
