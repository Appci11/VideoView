﻿namespace VideoView.Models.StoryScriptParts
{
    public class StoryObserverPart
    {
        public string Title { get; set; } = "story_observer";
        public string VideoUri { get; set; } = string.Empty;
        public List<Period> Periods { get; set; } = new List<Period>();
        public bool ShowDetails { get; set; }
    }

    public class Period
    {
        public int Time { get; set; }
        public bool Done { get; set; } = false;
        public string Exec { get; set; } = string.Empty;
    }
}
