namespace VideoView.Models.StoryScriptParts
{
    public class StoryObserverPart
    {
        public string Title { get; set; } = "story_observer";
        public List<Period> Periods { get; set; } = new List<Period>();
    }

    public class Period
    {
        public int Time { get; set; }
        public bool Done { get; set; }
        public string Exec { get; set; } = string.Empty;
    }
}
