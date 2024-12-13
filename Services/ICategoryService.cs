// Services/ICategoryService.cs
using System.Collections.Generic;
using System.Threading.Tasks;


public interface ICategoryService
{
    Task<List<Category>> GetAllCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(int id);
    Task<Category> AddCategoryAsync(Category category);
    Task<Category> UpdateCategoryAsync(Category category);
    Task DeleteCategoryAsync(int id);
}