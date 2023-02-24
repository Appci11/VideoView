using VideoView.Models.Cat;

namespace VideoView.Services.CatsService
{
    public interface ICatsService
    {
        public List<Cat> Cats { get; set; }

        Task GetAllCats();
        Task<Cat> GetCatById(string id);
        Task AddCat(Cat cat);
        Task UpdateCat(Cat cat);
        Task DeleteCat(string id);
    }
}
