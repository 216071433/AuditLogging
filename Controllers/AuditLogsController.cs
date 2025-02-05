using AuditLogging.Data;
using AuditLogging.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("audit/logs")]
[ApiController]
public class AuditLogsController : ControllerBase
{
    private readonly AuditDbContext _context;

    public AuditLogsController(AuditDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuditLog>>> GetLogs()
    {
        return await _context.AuditLogs.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<AuditLog>> CreateLog(AuditLog log)
    {
        _context.AuditLogs.Add(log);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetLogs), new { id = log.Id }, log);
    }
}
