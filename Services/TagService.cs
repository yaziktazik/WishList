// Services/TagService.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class TagService : ITagService
{
    private readonly WishlistAppDbContext _dbContext;

    public TagService(WishlistAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Tag>> GetAllTagsAsync()
    {
        return await _dbContext.Tags.ToListAsync();
    }

    public async Task<Tag> GetTagByIdAsync(int id)
    {
        return await _dbContext.Tags.FindAsync(id);
    }

    public async Task<Tag> AddTagAsync(Tag tag)
    {
        _dbContext.Tags.Add(tag);
        await _dbContext.SaveChangesAsync();
        return tag;
    }

    public async Task<Tag> UpdateTagAsync(Tag tag)
    {
        _dbContext.Tags.Update(tag);
        await _dbContext.SaveChangesAsync();
        return tag;
    }

    public async Task DeleteTagAsync(int id)
    {
        var tag = await _dbContext.Tags.FindAsync(id);
        if (tag != null)
        {
            _dbContext.Tags.Remove(tag);
            await _dbContext.SaveChangesAsync();
        }
    }
}