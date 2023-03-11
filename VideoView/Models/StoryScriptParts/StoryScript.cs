namespace VideoView.Models.StoryScriptParts
{
    public class StoryScript
    {
        public List<StoryPart> StoryParts { get; set; } = new List<StoryPart>();
        public List<string> StoryPartsAudioFileNames { get; set; } = new List<string>();
        public List<QuizPart> QuizParts { get; set; } = new List<QuizPart>();
        public List<string> QuizPartsAudioFileNames { get; set; } = new List<string>();
        public List<StoryMenuPart> StoryMenuParts { get; set;} = new List<StoryMenuPart>();
        public List<StoryObserverPart> StoryObserverParts { get; set;} = new List<StoryObserverPart>();
    }
}
