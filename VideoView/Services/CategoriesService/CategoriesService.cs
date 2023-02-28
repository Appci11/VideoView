﻿using Newtonsoft.Json;
using System.Net.Http.Json;
using VideoView.Models.Category;

namespace VideoView.Services.CategoriesService
{
    public class CategoriesService : ICategoriesService
    {
        const string resUrl = "https://firestore.googleapis.com/v1/";
        const string databaseUrl = "projects/rolka-videosmth/databases/(default)/";

        private readonly HttpClient _http;

        public CategoriesService(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<Category>> GetAllCategories(string uId)
        {
            var response = await _http.GetStringAsync($"{resUrl}{databaseUrl}documents/users/{uId}/categories");
            CategoryDocuments docs = JsonConvert.DeserializeObject<CategoryDocuments>(response);
            if(docs != null)
            {
                return docs.documents;
            }
            return null;
        }

        public async Task<bool> AddCategory(Category category, string userId)
        {
            var response = await _http.PostAsJsonAsync($"{resUrl}{databaseUrl}documents/users/{userId}/categories?documentId={category.fields.name.stringValue}",
                new {fields = category.fields });
            if(response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

    }
}
