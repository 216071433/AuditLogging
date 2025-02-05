using AuditLogging.Data;
using AuditLogging.Models;
using Microsoft.AspNetCore.Mvc;

[Route("audit/permissions")]
[ApiController]
public class PermissionsController : ControllerBase
{
    private readonly AuditDbContext _context;

    public PermissionsController(AuditDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Permission>> GetPermission(int id)
    {
        var permission = await _context.Permissions.FindAsync(id);
        if (permission == null) return NotFound();
        return permission;
    }

    [HttpPost]
    public async Task<ActionResult<Permission>> CreatePermission(Permission permission)
    {
        _context.Permissions.Add(permission);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPermission), new { id = permission.Id }, permission);
    }
}
