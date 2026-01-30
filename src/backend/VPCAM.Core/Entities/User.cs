using System;

namespace VPCAM.Core.Entities;

public class User
{
    public Guid Id { get; set; }
    public Guid ExternalIdentityId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string? CurrentRoleId { get; set; }
}
