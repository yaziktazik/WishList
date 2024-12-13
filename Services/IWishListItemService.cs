// Services/IWishListItemService.cs
using System.Collections.Generic;
using System.Threading.Tasks;


public interface IWishListItemService
{
    Task<List<WishListItem>> GetAllWishListItemsAsync();
    Task<WishListItem> GetWishListItemByIdAsync(int id);
    Task<WishListItem> AddWishListItemAsync(WishListItem wishListItem);
    Task<WishListItem> UpdateWishListItemAsync(WishListItem wishListItem);
    Task DeleteWishListItemAsync(int id);
}