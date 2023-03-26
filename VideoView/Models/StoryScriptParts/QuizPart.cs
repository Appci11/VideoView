namespace VideoView.Models.StoryScriptParts
{
    public class QuizPart
    {
        public string Title { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Nr { get; set; }
        public int CorrectNr { get; set; }
        // Speech berods galima praleist, tai praleista, nors 1-oj vietoj in .xml ir egzistuoja
        public List<Option> Options { get; set; } = new List<Option>();
        public bool ShowDetails { get; set; }
    }

    public class Option
    {
        // Has "Name". Skipped here. Generated automatically in .xml
        public int OX { get; set; }
        public int OY { get; set; }
        public string Text { get; set; } = string.Empty;
        public bool IsTrue { get; set; }
        public string Answer { get; set; } = string.Empty;
        public double Wait { get; set; }
        public string? Speech { get; set; }

        //string mp3BaseUri = string.Empty;
        //string mp3FileName = string.Empty;

        //public string Mp3BaseUri
        //{
        //    get { return mp3BaseUri; }
        //    set
        //    {
        //        mp3BaseUri = value;
        //        Speech = mp3BaseUri + mp3FileName;
        //    }
        //}

        //public string Mp3FileName
        //{
        //    get { return mp3FileName; }
        //    set
        //    {
        //        mp3FileName = value;
        //        Speech = mp3BaseUri + mp3FileName;
        //    }
        //}
    }
}
