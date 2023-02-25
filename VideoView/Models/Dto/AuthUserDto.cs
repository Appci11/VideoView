namespace VideoView.Models.Dto
{
    public class AuthUserDto
    {
        public string email { get; set; }
        public string password { get; set; }
        public bool returnSecureToken { get; set; } = true;
    }
}
