// Services/CategoryService.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class CategoryService : ICategoryService
{
    private readonly WishlistAppDbContext _dbContext;

    public CategoryService(WishlistAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return await _dbContext.Categories.ToListAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        return await _dbContext.Categories.FindAsync(id);
    }

    public async Task<Category> AddCategoryAsync(Category category)
    {
        _dbContext.Categories.Add(category);
        await _dbContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category> UpdateCategoryAsync(Category category)
    {
        _dbContext.Categories.Update(category);
        await _dbContext.SaveChangesAsync();
        return category;
    }

    public async Task DeleteCategoryAsync(int id)
    {
        var category = await _dbContext.Categories.FindAsync(id);
        if (category != null)
        {
            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
        }
    }
}