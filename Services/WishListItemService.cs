// Services/WishListItemService.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class WishListItemService : IWishListItemService
{
    private readonly WishlistAppDbContext _dbContext;

    public WishListItemService(WishlistAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<WishListItem>> GetAllWishListItemsAsync()
    {
        return await _dbContext.WishListItems.ToListAsync();
    }

    public async Task<WishListItem> GetWishListItemByIdAsync(int id)
    {
        return await _dbContext.WishListItems.FindAsync(id);
    }

    public async Task<WishListItem> AddWishListItemAsync(WishListItem wishListItem)
    {
        _dbContext.WishListItems.Add(wishListItem);
        await _dbContext.SaveChangesAsync();
        return wishListItem;
    }

    public async Task<WishListItem> UpdateWishListItemAsync(WishListItem wishListItem)
    {
        _dbContext.WishListItems.Update(wishListItem);
        await _dbContext.SaveChangesAsync();
        return wishListItem;
    }

    public async Task DeleteWishListItemAsync(int id)
    {
        var wishListItem = await _dbContext.WishListItems.FindAsync(id);
        if (wishListItem != null)
        {
            _dbContext.WishListItems.Remove(wishListItem);
            await _dbContext.SaveChangesAsync();
        }
    }
}