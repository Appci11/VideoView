namespace VideoView.Models.StoryScriptParts
{
    public class StoryMenuPart
    {
        public string Title { get; set; } = "story_menu";
        public string Name { get; set; } = string.Empty;    //actually Language
        public List<Menu> Menus { get; set; } = new List<Menu>();
    }

    public class Menu
    {
        // name dali generuos automatiskai
        public string Text { get; set; } = string.Empty;
        public int OX { get; set; }
        public int OY { get; set; }
        public string Action { get; set; } = string.Empty;
    }
}
