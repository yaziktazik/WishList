// Controllers/CommentsController.cs
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentsController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllComments()
    {
        var comments = await _commentService.GetAllCommentsAsync();
        return Ok(comments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCommentById(int id)
    {
        var comment = await _commentService.GetCommentByIdAsync(id);
        if (comment == null)
        {
            return NotFound();
        }
        return Ok(comment);
    }

    [HttpPost]
    public async Task<IActionResult> AddComment(Comment comment)
    {
        var addedComment = await _commentService.AddCommentAsync(comment);
        return CreatedAtAction(nameof(GetCommentById), new { id = addedComment.Id }, addedComment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateComment(int id, Comment comment)
    {
        if (id != comment.Id)
        {
            return BadRequest();
        }
        var updatedComment = await _commentService.UpdateCommentAsync(comment);
        return Ok(updatedComment);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComment(int id)
    {
        await _commentService.DeleteCommentAsync(id);
        return NoContent();
    }
}