public interface IPermissionService
{
    Task<List<Permission>> GetAllPermissionsAsync();
    Task<Permission> GetPermissionByIdAsync(int id);
    Task<Permission> AddPermissionAsync(Permission permission);
    Task<Permission> UpdatePermissionAsync(Permission permission);
    Task DeletePermissionAsync(int id);
}