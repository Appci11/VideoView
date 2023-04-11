using Newtonsoft.Json;
using System.Text;
using VideoView.Models;
using VideoView.Models.Category;
using VideoView.Models.Project;
using VideoView.Models.StoryScriptParts;
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
        public string VideoUrl { get; set; } = string.Empty;
        public string VideoToken { get; set;} = string.Empty;

        public WorkspaceService(ICategoriesService categoriesService, IProjectsService projectsService)
        {
            _categoriesService = categoriesService;
            _projectsService = projectsService;
        }

        public async Task GetProjectData(string categoryId, string projectId)
        {
            Category category = await _categoriesService.GetCategoryById(CategoryId);
            CategoryName = category.fields.name.stringValue;
            Project = await _projectsService.GetProjectById(categoryId, projectId);
            projectName = Project.fields.name.stringValue;
            if (Project.fields.blobFile.bytesValue.Length > 0)
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

        public void AddStoryScriptPart(StoryPart storyPart)
        {
            // Need a new copy...
            StoryPart temp = new StoryPart();
            temp.Title = storyPart.Title;
            temp.Name = storyPart.Name;
            temp.Speech = storyPart.Speech;
            foreach (Talk item in storyPart.Talks)
            {
                temp.Talks.Add(item);
            }
            WorkClass.StoryScript.StoryParts.Add(temp);
        }

        public void UpdateStoryScriptPart(StoryPart storyPart, int index)
        {
            // Need a new copy...
            WorkClass.StoryScript.StoryParts[index].Title = storyPart.Title;
            WorkClass.StoryScript.StoryParts[index].Name = storyPart.Name;
            WorkClass.StoryScript.StoryParts[index].Speech = storyPart.Speech;
            WorkClass.StoryScript.StoryParts[index].Talks.Clear();
            foreach (Talk item in storyPart.Talks)
            {
                WorkClass.StoryScript.StoryParts[index].Talks.Add(item);
            }
        }
        public void RemoveStoryScriptPart(int index)
        {
            this.WorkClass.StoryScript.StoryParts.RemoveAt(index);
        }

        public void AddStoryScriptQuizPart(QuizPart quizPart)
        {
            // Making new copy
            QuizPart temp = new QuizPart();
            temp.Title = quizPart.Title;
            temp.Name = quizPart.Name;
            temp.Nr = quizPart.Nr;
            temp.CorrectNr = quizPart.CorrectNr;
            foreach (Option item in quizPart.Options)
            {
                temp.Options.Add(item);
            }
            WorkClass.StoryScript.QuizParts.Add(temp);
        }

        public void UpdateStoryScriptQuizPart(QuizPart quizPart, int index)
        {
            // copying values not pointers
            WorkClass.StoryScript.QuizParts[index].Title = quizPart.Title;
            WorkClass.StoryScript.QuizParts[index].Name = quizPart.Name;
            WorkClass.StoryScript.QuizParts[index].Nr = quizPart.Nr;
            WorkClass.StoryScript.QuizParts[index].CorrectNr = quizPart.CorrectNr;
            WorkClass.StoryScript.QuizParts[index].Options.Clear();
            foreach (Option item in quizPart.Options)
            {
                WorkClass.StoryScript.QuizParts[index].Options.Add(item);
            }
        }

        public void RemoveStoryScriptQuizPart(int index)
        {
            WorkClass.StoryScript.QuizParts.RemoveAt(index);
        }

        public void AddStoryScriptStoryMenuPart(StoryMenuPart storyMenuPart)
        {
            StoryMenuPart temp = new StoryMenuPart();
            temp.Title = storyMenuPart.Title;
            temp.Name = storyMenuPart.Name;
            foreach (Menu item in storyMenuPart.Menus)
            {
                temp.Menus.Add(item);
            }
            WorkClass.StoryScript.StoryMenuParts.Add(temp);
        }

        public void UpdateStoryScriptStoryMenuPart(StoryMenuPart storyMenuPart, int index)
        {
            WorkClass.StoryScript.StoryMenuParts[index].Title = storyMenuPart.Title;
            WorkClass.StoryScript.StoryMenuParts[index].Name = storyMenuPart.Name;
            WorkClass.StoryScript.StoryMenuParts[index].Menus.Clear();
            foreach (Menu item in storyMenuPart.Menus)
            {
                WorkClass.StoryScript.StoryMenuParts[index].Menus.Add(item);
            }

        }

        public void RemoveStoryScriptStoryMenuPart(int index)
        {
            WorkClass.StoryScript.StoryMenuParts.RemoveAt(index);
        }

        public void AddStoryScriptStoryObserverPart(StoryObserverPart storyObserverPart)
        {
            StoryObserverPart temp = new StoryObserverPart();
            temp.Title = storyObserverPart.Title;
            temp.VideoUri = storyObserverPart.VideoUri;
            foreach (Period item in storyObserverPart.Periods)
            {
                temp.Periods.Add(item);
            }
            WorkClass.StoryScript.StoryObserverParts.Add(temp);
        }

        public void UpdateStoryScriptStoryObserverPart(StoryObserverPart storyObserverPart, int index)
        {
            WorkClass.StoryScript.StoryObserverParts[index].Title = storyObserverPart.Title;
            WorkClass.StoryScript.StoryObserverParts[index].VideoUri = storyObserverPart.VideoUri;
            WorkClass.StoryScript.StoryObserverParts[index].Periods.Clear();
            foreach (Period item in storyObserverPart.Periods)
            {
                WorkClass.StoryScript.StoryObserverParts[index].Periods.Add(item);
            }
        }

        public void RemoveStoryScriptStoryObserverPart(int index)
        {
            WorkClass.StoryScript.StoryObserverParts.RemoveAt(index);
        }

    }
}
