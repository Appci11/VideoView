
using VideoView.Models.Category;

namespace VideoView.Services.CategoriesService
{
    public interface ICategoriesService
    {
        public Task<List<Category>> GetAllCategories(string uId);
        public Task<bool> AddCategory(Category category, string userId);
    }
}
