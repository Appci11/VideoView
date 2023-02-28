using Newtonsoft.Json;
using VideoView.Models.Category;
using VideoView.Models.Project;

namespace VideoView.Services.ProjectsService
{
    public class ProjectsService : IProjectsService
    {
        const string resUrl = "https://firestore.googleapis.com/v1/";
        const string databaseUrl = "projects/rolka-videosmth/databases/(default)/";

        private readonly HttpClient _http;

        public ProjectsService(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<Project>> GetAllProjects(string uId, string cId)
        {
            var response = await _http.GetStringAsync($"{resUrl}{databaseUrl}documents/users/{uId}/categories/{cId}/projects");
            ProjectDocuments docs = JsonConvert.DeserializeObject<ProjectDocuments>(response);
            if (docs != null)
            {
                return docs.documents;
            }
            return null;
        }
    }
}
