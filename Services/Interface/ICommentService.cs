// Services/ICommentService.cs
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICommentService
{
    Task<List<Comment>> GetAllCommentsAsync();
    Task<Comment> GetCommentByIdAsync(int id);
    Task<Comment> AddCommentAsync(Comment comment);
    Task<Comment> UpdateCommentAsync(Comment comment);
    Task DeleteCommentAsync(int id);
}