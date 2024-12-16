// Services/IWishListService.cs
using System.Collections.Generic;
using System.Threading.Tasks;


public interface IWishListService
{
    Task<List<WishList>> GetAllWishListsAsync();
    Task<WishList> GetWishListByIdAsync(int id);
    Task<WishList> AddWishListAsync(WishList wishList);
    Task<WishList> UpdateWishListAsync(WishList wishList);
    Task DeleteWishListAsync(int id);
}