// Services/ItemService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class ItemService : IItemService
{
    private readonly WishlistAppDbContext _dbContext;

    public ItemService(WishlistAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Item>> GetAllItemsAsync()
    {
        return await _dbContext.Items.ToListAsync();
    }

    public async Task<Item> GetItemByIdAsync(int id)
    {
        return await _dbContext.Items.FindAsync(id);
    }

    public async Task<Item> AddItemAsync(Item item)
    {
        _dbContext.Items.Add(item);
        await _dbContext.SaveChangesAsync();
        return item;
    }

    public async Task<Item> UpdateItemAsync(Item item)
    {
        _dbContext.Items.Update(item);
        await _dbContext.SaveChangesAsync();
        return item;
    }

    public async Task DeleteItemAsync(int id)
    {
        var item = await _dbContext.Items.FindAsync(id);
        if (item != null)
        {
            _dbContext.Items.Remove(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}