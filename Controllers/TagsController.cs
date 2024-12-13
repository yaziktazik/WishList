// Controllers/TagsController.cs
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class TagsController : ControllerBase
{
    private readonly ITagService _tagService;

    public TagsController(ITagService tagService)
    {
        _tagService = tagService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTags()
    {
        var tags = await _tagService.GetAllTagsAsync();
        return Ok(tags);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTagById(int id)
    {
        var tag = await _tagService.GetTagByIdAsync(id);
        if (tag == null)
        {
            return NotFound();
        }
        return Ok(tag);
    }

    [HttpPost]
    public async Task<IActionResult> AddTag(Tag tag)
    {
        var addedTag = await _tagService.AddTagAsync(tag);
        return CreatedAtAction(nameof(GetTagById), new { id = addedTag.Id }, addedTag);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTag(int id, Tag tag)
    {
        if (id != tag.Id)
        {
            return BadRequest();
        }
        var updatedTag = await _tagService.UpdateTagAsync(tag);
        return Ok(updatedTag);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTag(int id)
    {
        await _tagService.DeleteTagAsync(id);
        return NoContent();
    }
}