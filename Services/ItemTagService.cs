// Services/ItemTagService.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class ItemTagService : IItemTagService
{
    private readonly WishlistAppDbContext _dbContext;

    public ItemTagService(WishlistAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ItemTag>> GetAllItemTagsAsync()
    {
        return await _dbContext.ItemTags.ToListAsync();
    }

    public async Task<ItemTag> GetItemTagByIdAsync(int id)
    {
        return await _dbContext.ItemTags.FindAsync(id);
    }

    public async Task<ItemTag> AddItemTagAsync(ItemTag itemTag)
    {
        _dbContext.ItemTags.Add(itemTag);
        await _dbContext.SaveChangesAsync();
        return itemTag;
    }

    public async Task<ItemTag> UpdateItemTagAsync(ItemTag itemTag)
    {
        _dbContext.ItemTags.Update(itemTag);
        await _dbContext.SaveChangesAsync();
        return itemTag;
    }

    public async Task DeleteItemTagAsync(int id)
    {
        var itemTag = await _dbContext.ItemTags.FindAsync(id);
        if (itemTag != null)
        {
            _dbContext.ItemTags.Remove(itemTag);
            await _dbContext.SaveChangesAsync();
        }
    }
}