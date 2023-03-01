
using VideoView.Models.Category;

namespace VideoView.Services.CategoriesService
{
    public interface ICategoriesService
    {
        public Task<List<Category>> GetAllCategories();
        public Task<bool> AddCategory(Category category);
    }
}
