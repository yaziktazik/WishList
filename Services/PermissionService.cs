using Microsoft.EntityFrameworkCore;

public class PermissionService : IPermissionService
{
    private readonly WishlistAppDbContext _dbContext;

    public PermissionService(WishlistAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Permission>> GetAllPermissionsAsync()
    {
        return await _dbContext.Permissions.ToListAsync();
    }

    public async Task<Permission> GetPermissionByIdAsync(int id)
    {
        return await _dbContext.Permissions.FindAsync(id);
    }

    public async Task<Permission> AddPermissionAsync(Permission permission)
    {
        _dbContext.Permissions.Add(permission);
        await _dbContext.SaveChangesAsync();
        return permission;
    }

    public async Task<Permission> UpdatePermissionAsync(Permission permission)
    {
        _dbContext.Permissions.Update(permission);
        await _dbContext.SaveChangesAsync();
        return permission;
    }

    public async Task DeletePermissionAsync(int id)
    {
        var permission = await _dbContext.Permissions.FindAsync(id);
        if (permission != null)
        {
            _dbContext.Permissions.Remove(permission);
            await _dbContext.SaveChangesAsync();
        }
    }
}