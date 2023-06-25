using VideoManagementApi.Domain.Common;

namespace VideoManagementApi.Domain.Entities;

public class AccessToken : BaseEntity, IEntity
{
    public string Token { get; set; }
    public bool IsValid { get; set; }
    public int? UserId { get; set; }
    public User? User { get; set; }
}