using VideoView.Models;
using VideoView.Models.Project;
using VideoView.Models.StoryScriptParts;

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

        public Task GetProjectData(string categoryId, string projectId);
        public Task<bool> SendProjectDataToServer();

        public void AddStoryScriptPart(StoryPart storyPart);
        public void UpdateStoryScriptPart(StoryPart storyPart, int index);
        public void RemoveStoryScriptPart(int index);

        public void AddStoryScriptQuizPart(QuizPart quizPart);
        public void UpdateStoryScriptQuizPart(QuizPart quizPart, int index);
        public void RemoveStoryScriptQuizPart(int index);

        public void AddStoryScriptStoryMenuPart(StoryMenuPart storyMenuPart);
        public void UpdateStoryScriptStoryMenuPart(StoryMenuPart storyMenuPart, int index);
        public void RemoveStoryScriptStoryMenuPart(int index);

        public void AddStoryScriptStoryObserverPart(StoryObserverPart storyObserverPart);
        public void UpdateStoryScriptStoryObserverPart(StoryObserverPart storyObserverPart, int index);
        public void RemoveStoryScriptStoryObserverPart(int index);
    }    
}
