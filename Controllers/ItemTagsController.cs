// Controllers/ItemTagsController.cs
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ItemTagsController : ControllerBase
{
    private readonly IItemTagService _itemTagService;

    public ItemTagsController(IItemTagService itemTagService)
    {
        _itemTagService = itemTagService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllItemTags()
    {
        var itemTags = await _itemTagService.GetAllItemTagsAsync();
        return Ok(itemTags);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetItemTagById(int id)
    {
        var itemTag = await _itemTagService.GetItemTagByIdAsync(id);
        if (itemTag == null)
        {
            return NotFound();
        }
        return Ok(itemTag);
    }

    [HttpPost]
    public async Task<IActionResult> AddItemTag(ItemTag itemTag)
    {
        var addedItemTag = await _itemTagService.AddItemTagAsync(itemTag);
        return CreatedAtAction(nameof(GetItemTagById), new { id = addedItemTag.Id }, addedItemTag);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateItemTag(int id, ItemTag itemTag)
    {
        if (id != itemTag.Id)
        {
            return BadRequest();
        }
        var updatedItemTag = await _itemTagService.UpdateItemTagAsync(itemTag);
        return Ok(updatedItemTag);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItemTag(int id)
    {
        await _itemTagService.DeleteItemTagAsync(id);
        return NoContent();
    }
}