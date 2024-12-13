// Services/IItemService.cs
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IItemService
{
    Task<List<Item>> GetAllItemsAsync();
    Task<Item> GetItemByIdAsync(int id);
    Task<Item> AddItemAsync(Item item);
    Task<Item> UpdateItemAsync(Item item);
    Task DeleteItemAsync(int id);
}