// Services/IItemTagService.cs
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IItemTagService
{
    Task<List<ItemTag>> GetAllItemTagsAsync();
    Task<ItemTag> GetItemTagByIdAsync(int id);
    Task<ItemTag> AddItemTagAsync(ItemTag itemTag);
    Task<ItemTag> UpdateItemTagAsync(ItemTag itemTag);
    Task DeleteItemTagAsync(int id);
}