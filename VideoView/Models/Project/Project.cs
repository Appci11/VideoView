namespace VideoView.Models.Project
{
    public class Project
    {
        public string name { get; set; } = string.Empty;  //automatically given by db, must not be set!
        public Fields fields { get; set; } = new Fields();  //required by db
        public DateTime createTime { get; set; }    //automatically given by db
        public DateTime updateTime { get; set; }    //automatically given by db
    }
    public class Fields
    {
        public Name name { get; set; } = new Name();
        public BlobFile blobFile { get; set; } = new BlobFile();
    }

    public class Name
    {
        public string stringValue { get; set; } = string.Empty;
    }
    public class BlobFile
    {
        public byte[] bytesValue { get; set; } = new byte[0];
    }
}
