using VideoView.Models.Project;

namespace VideoView.Services.ProjectsService
{
    public interface IProjectsService
    {
        public Task<List<Project>> GetAllProjects(string categoryId);
        public Task<Project> GetProjectById(string categoryId, string id);
        public Task<bool> AddProject(Project project, string categoryId);
        public Task<bool> UpdateProject(Project project, string categoryId, string id);
        public Task<bool> DeleteProject(string categoryId, string id);
    }
}
