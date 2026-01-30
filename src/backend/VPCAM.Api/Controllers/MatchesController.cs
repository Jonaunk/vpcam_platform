using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VPCAM.Api.Infrastructure.Data;
using VPCAM.Core.Entities;

namespace VPCAM.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MatchesController : ControllerBase
{
    private readonly VpcamDbContext _db;

    public MatchesController(VpcamDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> List([FromQuery] int? venueId, [FromQuery] DateTime? date)
    {
        var query = _db.Matches.AsQueryable();

        if (venueId.HasValue)
        {
            query = query.Where(m => m.Court != null && m.Court.VenueId == venueId.Value);
        }

        if (date.HasValue)
        {
            query = query.Where(m => m.StartTime.Date == date.Value.Date);
        }

        var matches = await query
            .Include(m => m.Court)
            .OrderByDescending(m => m.StartTime)
            .Take(50)
            .Select(m => new { 
                m.Id, 
                m.Status, 
                StatusString = m.Status.ToString(),
                m.StartTime,
                CourtName = m.Court != null ? m.Court.Name : "Unknown"
            })
            .ToListAsync();
            
        return Ok(matches);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
         var match = await _db.Matches.FindAsync(id);
         if (match == null) return NotFound();
         
         return Ok(new { 
            match.Id, 
            StreamUrl = match.CdnUrl 
         });
    }
}
