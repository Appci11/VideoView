namespace VideoView.Models.StoryScriptParts
{
    public class StoryPart
    {
        public string Title { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;    // in xml called name, in reality - language
        public string? Speech { get; set; }
        public List<Talk> Talks { get; set; } = new List<Talk>();
    }

    public class Talk
    {
        public string Text { get; set; } = String.Empty;
        public double Wait { get; set; }
    }
}
