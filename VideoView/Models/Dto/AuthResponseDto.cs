namespace VideoView.Models.Dto
{
    public class AuthResponseDto
    {
        public string email { get; set; }
        public string expiresIn { get; set; }
        public string idToken { get; set; }
        public string kind { get; set; }
        public string localId { get; set; }
        public string refreshToken { get; set; }
    }
}
