namespace VideoView.Models
{
    public class FileUploadResponse
    {
        public string name { get; set; } = string.Empty;
        public string bucket { get; set; } = string.Empty;
        public string downloadTokens { get; set; } = string.Empty;
    }
}
