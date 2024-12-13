using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PermissionsController : ControllerBase
{
    private readonly IPermissionService _permissionService;

    public PermissionsController(IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPermissions()
    {
        var permissions = await _permissionService.GetAllPermissionsAsync();
        return Ok(permissions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPermissionById(int id)
    {
        var permission = await _permissionService.GetPermissionByIdAsync(id);
        if (permission == null)
        {
            return NotFound();
        }
        return Ok(permission);
    }

    [HttpPost]
    public async Task<IActionResult> AddPermission(Permission permission)
    {
        var addedPermission = await _permissionService.AddPermissionAsync(permission);
        return CreatedAtAction(nameof(GetPermissionById), new { id = addedPermission.Id }, addedPermission);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePermission(int id, Permission permission)
    {
        if (id != permission.Id)
        {
            return BadRequest();
        }
        var updatedPermission = await _permissionService.UpdatePermissionAsync(permission);
        return Ok(updatedPermission);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePermission(int id)
    {
        await _permissionService.DeletePermissionAsync(id);
        return NoContent();
    }
}