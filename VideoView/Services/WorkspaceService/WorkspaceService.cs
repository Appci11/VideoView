using Newtonsoft.Json;
using System.Text;
using VideoView.Models;
using VideoView.Models.Category;
using VideoView.Models.Project;
using VideoView.Services.CategoriesService;
using VideoView.Services.ProjectsService;

namespace VideoView.Services.WorkspaceService
{
    public class WorkspaceService : IWorkspaceService
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IProjectsService _projectsService;

        public string CategoryId { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string ProjectId { get; set; } = string.Empty;
        public string projectName { get; set; } = string.Empty;
        public Project Project { get; set; } = new Project();
        public WorkClass WorkClass { get; set; } = new WorkClass();

        public WorkspaceService(ICategoriesService categoriesService, IProjectsService projectsService)
        {
            _categoriesService = categoriesService;
            _projectsService = projectsService;
        }

        public async Task GetProjectData()
        {
            Category category = await _categoriesService.GetCategoryById(CategoryId);
            CategoryName = category.fields.name.stringValue;
            Project = await _projectsService.GetProjectById(CategoryId, ProjectId);
            projectName = Project.fields.name.stringValue;
            if(Project.fields.blobFile.bytesValue.Length > 0)
            {
                WorkClass = ByteToObj<WorkClass>(Project.fields.blobFile.bytesValue);
            }
        }

        //gal i bool pakeist reiketu...
        public async Task<bool> SendProjectDataToServer()
        {
            Project.fields.blobFile.bytesValue = ObjToByte<WorkClass>(WorkClass);
            return await _projectsService.UpdateProject(Project, CategoryId, ProjectId);
        }

        TData ByteToObj<TData>(byte[] arr)
        {
            return JsonConvert.DeserializeObject<TData>(Encoding.UTF8.GetString(arr));
        }

        byte[] ObjToByte<TData>(TData data)
        {
            var json = JsonConvert.SerializeObject(data);
            return Encoding.UTF8.GetBytes(json);
        }
    }
}
