public interface IRoleService
{
    Task<List<Role>> GetAllRolesAsync();
    Task<Role> GetRoleByIdAsync(int id);
    Task<Role> AddRoleAsync(Role role);
    Task<Role> UpdateRoleAsync(Role role);
    Task DeleteRoleAsync(int id);
}