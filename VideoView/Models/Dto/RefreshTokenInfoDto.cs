namespace VideoView.Models.Dto
{
    public class RefreshTokenInfoDto
    {
        public string expires_in { get ; set; }
        public string token_type { get; set; } = "Bearer";
        public string refresh_token { get; set; }
        public string id_token { get; set; }
        public string user_id { get; set; }
        public string project_id { get; set; }
    }
}
