// Controllers/WishListsController.cs
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class WishListsController : ControllerBase
{
    private readonly IWishListService _wishListService;

    public WishListsController(IWishListService wishListService)
    {
        _wishListService = wishListService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWishLists()
    {
        var wishLists = await _wishListService.GetAllWishListsAsync();
        return Ok(wishLists);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetWishListById(int id)
    {
        var wishList = await _wishListService.GetWishListByIdAsync(id);
        if (wishList == null)
        {
            return NotFound();
        }
        return Ok(wishList);
    }

    [HttpPost]
    public async Task<IActionResult> AddWishList(WishList wishList)
    {
        var addedWishList = await _wishListService.AddWishListAsync(wishList);
        return CreatedAtAction(nameof(GetWishListById), new { id = addedWishList.Id }, addedWishList);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWishList(int id, WishList wishList)
    {
        if (id != wishList.Id)
        {
            return BadRequest();
        }
        var updatedWishList = await _wishListService.UpdateWishListAsync(wishList);
        return Ok(updatedWishList);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWishList(int id)
    {
        await _wishListService.DeleteWishListAsync(id);
        return NoContent();
    }
}