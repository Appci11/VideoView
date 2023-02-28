using VideoView.Models.Project;

namespace VideoView.Services.ProjectsService
{
    public interface IProjectsService
    {
        public Task<List<Project>> GetAllProjects(string uId, string cId);
    }
}
