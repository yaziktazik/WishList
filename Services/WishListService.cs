// Services/WishListService.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class WishListService : IWishListService
{
    private readonly WishlistAppDbContext _dbContext;

    public WishListService(WishlistAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<WishList>> GetAllWishListsAsync()
    {
        return await _dbContext.WishLists.ToListAsync();
    }

    public async Task<WishList> GetWishListByIdAsync(int id)
    {
        return await _dbContext.WishLists.FindAsync(id);
    }

    public async Task<WishList> AddWishListAsync(WishList wishList)
    {
        _dbContext.WishLists.Add(wishList);
        await _dbContext.SaveChangesAsync();
        return wishList;
    }

    public async Task<WishList> UpdateWishListAsync(WishList wishList)
    {
        _dbContext.WishLists.Update(wishList);
        await _dbContext.SaveChangesAsync();
        return wishList;
    }

    public async Task DeleteWishListAsync(int id)
    {
        var wishList = await _dbContext.WishLists.FindAsync(id);
        if (wishList != null)
        {
            _dbContext.WishLists.Remove(wishList);
            await _dbContext.SaveChangesAsync();
        }
    }
}