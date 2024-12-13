// Controllers/ItemsController.cs
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemsController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllItems()
    {
        var items = await _itemService.GetAllItemsAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetItemById(int id)
    {
        var item = await _itemService.GetItemByIdAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> AddItem(Item item)
    {
        var addedItem = await _itemService.AddItemAsync(item);
        return CreatedAtAction(nameof(GetItemById), new { id = addedItem.Id }, addedItem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateItem(int id, Item item)
    {
        if (id != item.Id)
        {
            return BadRequest();
        }
        var updatedItem = await _itemService.UpdateItemAsync(item);
        return Ok(updatedItem);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        await _itemService.DeleteItemAsync(id);
        return NoContent();
    }
}