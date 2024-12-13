using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RolesController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RolesController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRoles()
    {
        var roles = await _roleService.GetAllRolesAsync();
        return Ok(roles);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoleById(int id)
    {
        var role = await _roleService.GetRoleByIdAsync(id);
        if (role == null)
        {
            return NotFound();
        }
        return Ok(role);
    }

    [HttpPost]
    public async Task<IActionResult> AddRole(Role role)
    {
        var addedRole = await _roleService.AddRoleAsync(role);
        return CreatedAtAction(nameof(GetRoleById), new { id = addedRole.Id }, addedRole);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRole(int id, Role role)
    {
        if (id != role.Id)
        {
            return BadRequest();
        }
        var updatedRole = await _roleService.UpdateRoleAsync(role);
        return Ok(updatedRole);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRole(int id)
    {
        await _roleService.DeleteRoleAsync(id);
        return NoContent();
    }
}