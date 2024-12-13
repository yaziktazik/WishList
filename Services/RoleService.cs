using Microsoft.EntityFrameworkCore;

public class RoleService : IRoleService
{
    private readonly WishlistAppDbContext _dbContext;

    public RoleService(WishlistAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Role>> GetAllRolesAsync()
    {
        return await _dbContext.Roles.ToListAsync();
    }

    public async Task<Role> GetRoleByIdAsync(int id)
    {
        return await _dbContext.Roles.FindAsync(id);
    }

    public async Task<Role> AddRoleAsync(Role role)
    {
        _dbContext.Roles.Add(role);
        await _dbContext.SaveChangesAsync();
        return role;
    }

    public async Task<Role> UpdateRoleAsync(Role role)
    {
        _dbContext.Roles.Update(role);
        await _dbContext.SaveChangesAsync();
        return role;
    }

    public async Task DeleteRoleAsync(int id)
    {
        var role = await _dbContext.Roles.FindAsync(id);
        if (role != null)
        {
            _dbContext.Roles.Remove(role);
            await _dbContext.SaveChangesAsync();
        }
    }
}