using AuditLogging.Data;
using AuditLogging.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("audit/records")]
[ApiController]
public class RecordsController : ControllerBase
{
    private readonly AuditDbContext _context;

    public RecordsController(AuditDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Record>>> GetRecords()
    {
        return await _context.Records.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Record>> GetRecord(int id)
    {
        var record = await _context.Records.FindAsync(id);
        if (record == null) return NotFound();
        return record;
    }

    [HttpPost]
    public async Task<ActionResult<Record>> CreateRecord(Record record)
    {
        _context.Records.Add(record);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetRecord), new { id = record.Id }, record);
    }
}

