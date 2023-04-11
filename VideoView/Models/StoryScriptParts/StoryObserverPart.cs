namespace VideoView.Models.StoryScriptParts
{
    public class StoryObserverPart
    {
        public string Title { get; set; } = "story_observer";
        public string VideoUri { get; set; } = string.Empty;
        public List<Period> Periods { get; set; } = new List<Period>();
        public bool ShowDetails { get; set; }
    }

    public class Period : IComparable<Period>
    {
        public double Time { get; set; }
        public bool Done { get; set; } = false;
        public string Exec { get; set; } = string.Empty;

        public int CompareTo(Period? obj)
        {
            if (obj == null) return 1;
            if (Time > obj.Time) return 1;
            if (obj.Time == Time) return 0;
            return -1;
        }
    }
}
