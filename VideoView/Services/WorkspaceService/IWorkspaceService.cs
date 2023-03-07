using VideoView.Models;
using VideoView.Models.Project;

namespace VideoView.Services.WorkspaceService
{
    public interface IWorkspaceService
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ProjectId { get; set; }
        public string projectName { get; set; }
        public Project Project { get; set; }
        public WorkClass WorkClass { get; set; }

        public Task GetProjectData();
        public Task<bool> SendProjectDataToServer();

    }

    
}
