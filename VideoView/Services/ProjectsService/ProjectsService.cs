using Blazored.LocalStorage;
using Newtonsoft.Json;
using System.Net.Http.Json;
using VideoView.Models.Category;
using VideoView.Models.Project;

namespace VideoView.Services.ProjectsService
{
    public class ProjectsService : IProjectsService
    {
        const string resUrl = "https://firestore.googleapis.com/v1/";
        const string databaseUrl = "projects/rolka-videosmth/databases/(default)/";

        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;

        public ProjectsService(HttpClient http, ILocalStorageService localStorage)
        {
            _http = http;
            _localStorage = localStorage;
        }


        public async Task<List<Project>> GetAllProjects(string categoryId)
        {
            string uId = await _localStorage.GetItemAsync<string>("userId");
            var response = await _http.GetStringAsync($"{resUrl}{databaseUrl}documents/users/{uId}/categories/{categoryId}/projects");
            ProjectDocuments docs = JsonConvert.DeserializeObject<ProjectDocuments>(response);
            if (docs != null)
            {
                return docs.documents;
            }
            return new List<Project>();
        }

        public async Task<Project> GetProjectById(string categoryId, string id)
        {
            string uId = await _localStorage.GetItemAsync<string>("userId");
            Project response = await _http.GetFromJsonAsync<Project>($"{resUrl}{databaseUrl}documents/users/{uId}/categories/{categoryId}/projects/{id}");
            if (response != null)
            {
                return response;
            }
            return null;
        }


        public async Task<bool> AddProject(Project project, string categoryId)
        {
            string uId = await _localStorage.GetItemAsync<string>("userId");
            var response = await _http.PostAsJsonAsync($"{resUrl}{databaseUrl}documents/users/{uId}/categories/{categoryId}/projects",
                new {fields = project.fields});           
            
            if (response != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateProject(Project project, string categoryId, string id)
        {
            string uId = await _localStorage.GetItemAsync<string>("userId");
            var response = await _http.PatchAsJsonAsync($"{resUrl}{databaseUrl}documents/users/{uId}/categories/{categoryId}/projects/{id}",
                new { fields = project.fields });
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteProject(string categoryId, string id)
        {
            string uId = await _localStorage.GetItemAsync<string>("userId");
            var response = await _http.DeleteAsync($"{resUrl}{databaseUrl}documents/users/{uId}/categories/{categoryId}/projects/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
