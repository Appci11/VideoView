using Blazored.LocalStorage;
using Newtonsoft.Json;
using System.Net.Http.Json;
using VideoView.Models.Cat;
using VideoView.Models.Category;

namespace VideoView.Services.CategoriesService
{
    public class CategoriesService : ICategoriesService
    {
        const string resUrl = "https://firestore.googleapis.com/v1/";
        const string databaseUrl = "projects/rolka-videosmth/databases/(default)/";

        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;

        public CategoriesService(HttpClient http, ILocalStorageService localStorage)
        {
            _http = http;
            _localStorage = localStorage;
        }
        public async Task<List<Category>> GetAllCategories()
        {
            string uId = await _localStorage.GetItemAsync<string>("userId");
            var response = await _http.GetStringAsync($"{resUrl}{databaseUrl}documents/users/{uId}/categories");
            CategoryDocuments docs = JsonConvert.DeserializeObject<CategoryDocuments>(response);
            if(docs != null)
            {
                return docs.documents;
            }
            return null;
        }

        public async Task<Category> GetCategoryById(string id)
        {
            string uId = await _localStorage.GetItemAsync<string>("userId");
            Category response = await _http.GetFromJsonAsync<Category>($"{resUrl}{databaseUrl}documents/users/{uId}/categories/{id}");
            if(response != null)
            {
                return response;
            }
            return null;
        }

        public async Task<bool> AddCategory(Category category)
        {
            string uId = await _localStorage.GetItemAsync<string>("userId");
            var response = await _http.PostAsJsonAsync($"{resUrl}{databaseUrl}documents/users/{uId}/categories",
                new {fields = category.fields });
            if(response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateCategory(Category category, string id)
        {
            string uId = await _localStorage.GetItemAsync<string>("userId");
            var response = await _http.PatchAsJsonAsync($"{resUrl}{databaseUrl}documents/users/{uId}/categories/{id}",
                new { fields = category.fields });
            if(response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteCategory(string id)
        {
            string uId = await _localStorage.GetItemAsync<string>("userId");
            var response = await _http.DeleteAsync($"{resUrl}{databaseUrl}documents/users/{uId}/categories/{id}");
            if(response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
