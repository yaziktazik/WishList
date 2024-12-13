// Services/CommentService.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class CommentService : ICommentService
{
    private readonly WishlistAppDbContext _dbContext;

    public CommentService(WishlistAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Comment>> GetAllCommentsAsync()
    {
        return await _dbContext.Comments.ToListAsync();
    }

    public async Task<Comment> GetCommentByIdAsync(int id)
    {
        return await _dbContext.Comments.FindAsync(id);
    }

    public async Task<Comment> AddCommentAsync(Comment comment)
    {
        _dbContext.Comments.Add(comment);
        await _dbContext.SaveChangesAsync();
        return comment;
    }

    public async Task<Comment> UpdateCommentAsync(Comment comment)
    {
        _dbContext.Comments.Update(comment);
        await _dbContext.SaveChangesAsync();
        return comment;
    }

    public async Task DeleteCommentAsync(int id)
    {
        var comment = await _dbContext.Comments.FindAsync(id);
        if (comment != null)
        {
            _dbContext.Comments.Remove(comment);
            await _dbContext.SaveChangesAsync();
        }
    }
}