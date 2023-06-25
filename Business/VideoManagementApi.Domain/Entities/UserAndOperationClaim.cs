using VideoManagementApi.Domain.Common;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Domain.ConfigureEntities;

public class UserAndOperationClaim : IEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid OperationClaimId { get; set; }
    public OperationClaim OperationClaim { get; set; }
}