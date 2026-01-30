using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VPCAM.Api.Infrastructure.Data;
using VPCAM.Core.Entities;

namespace VPCAM.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly VpcamDbContext _db;

    public UsersController(VpcamDbContext db)
    {
        _db = db;
    }

    [HttpPost("sync")]
    public async Task<IActionResult> Sync()
    {
        var subject = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(subject) || !Guid.TryParse(subject, out var externalId))
        {
            return BadRequest("Invalid Token: Missing sub claim");
        }

        var user = await _db.Users.FirstOrDefaultAsync(u => u.ExternalIdentityId == externalId);
        var isNew = false;

        if (user == null)
        {
            isNew = true;
            user = new User
            {
                ExternalIdentityId = externalId,
                Email = User.FindFirst(ClaimTypes.Email)?.Value ?? "",
                // Default Role logic or other initialization
            };
            _db.Users.Add(user);
        }
        else
        {
             // Update if needed
        }

        await _db.SaveChangesAsync();

        return Ok(new { localId = user.Id, isNew });
    }
}
