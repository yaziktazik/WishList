// Controllers/WishListItemsController.cs
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class WishListItemsController : ControllerBase
{
    private readonly IWishListItemService _wishListItemService;

    public WishListItemsController(IWishListItemService wishListItemService)
    {
        _wishListItemService = wishListItemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWishListItems()
    {
        var wishListItems = await _wishListItemService.GetAllWishListItemsAsync();
        return Ok(wishListItems);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetWishListItemById(int id)
    {
        var wishListItem = await _wishListItemService.GetWishListItemByIdAsync(id);
        if (wishListItem == null)
        {
            return NotFound();
        }
        return Ok(wishListItem);
    }

    [HttpPost]
    public async Task<IActionResult> AddWishListItem(WishListItem wishListItem)
    {
        var addedWishListItem = await _wishListItemService.AddWishListItemAsync(wishListItem);
        return CreatedAtAction(nameof(GetWishListItemById), new { id = addedWishListItem.Id }, addedWishListItem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWishListItem(int id, WishListItem wishListItem)
    {
        if (id != wishListItem.Id)
        {
            return BadRequest();
        }
        var updatedWishListItem = await _wishListItemService.UpdateWishListItemAsync(wishListItem);
        return Ok(updatedWishListItem);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWishListItem(int id)
    {
        await _wishListItemService.DeleteWishListItemAsync(id);
        return NoContent();
    }
}