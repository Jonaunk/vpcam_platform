using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VPCAM.Api.Infrastructure.Data;
using VPCAM.Core.Entities;

namespace VPCAM.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VenuesController : ControllerBase
{
    private readonly VpcamDbContext _context;

    public VenuesController(VpcamDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Venue>>> GetVenues()
    {
        return await _context.Venues.Include(v => v.Courts).ToListAsync();
    }
}
