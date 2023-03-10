namespace VideoView.Models.StoryScriptParts
{
    public class StoryScript
    {
        public List<string> StoryPartsAudioFileNames { get; set; } = new List<string>();
        public List<StoryPart> StoryParts { get; set; } = new List<StoryPart>();
    }
}
