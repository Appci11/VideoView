namespace VideoView.Models.Cat
{
    public class Cat
    {
        public string name { get; set; } = string.Empty;
        public Fields fields { get; set; } = new Fields();
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
    }

    public class Fields
    {
        public Name name { get; set; } = new Name();
    }

    public class Name
    {
        public string stringValue { get; set; } = string.Empty;
    }
}
