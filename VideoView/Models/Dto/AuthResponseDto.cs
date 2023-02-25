namespace VideoView.Models.Dto
{
    public class AuthResponseDto
    {
        public string email { get; set; }
        public int expiresiN { get; set; }
        public string idToken { get; set; }
        public string kind { get; set; }
        public string localId { get; set; }
        public string refreshToken { get; set; }
    }
}
