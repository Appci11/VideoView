
using VideoView.Models.Category;

namespace VideoView.Services.CategoriesService
{
    public interface ICategoriesService
    {
        public Task<List<Category>> GetAllCategories();
        public Task<Category> GetCategoryById(string id);
        public Task<bool> AddCategory(Category category);
        public Task<bool> UpdateCategory(Category category, string id);
        public Task<bool> DeleteCategory(string id);
    }
}
