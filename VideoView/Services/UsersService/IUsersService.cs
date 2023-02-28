namespace VideoView.Services.UsersService
{
    public interface IUsersService
    {
        Task<bool> CheckIfExistsById(string id);
        Task<bool> AddUser(string id);
    }
}
