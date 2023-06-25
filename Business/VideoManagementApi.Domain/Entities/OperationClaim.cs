using VideoManagementApi.Domain.Common;
using VideoManagementApi.Domain.ConfigureEntities;

namespace VideoManagementApi.Domain.Entities
{
    public class OperationClaim : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public ICollection<UserAndOperationClaim> UserAndOperationClaims { get; set; }
    }
}