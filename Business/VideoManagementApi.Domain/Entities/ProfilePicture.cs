using VideoManagementApi.Domain.Common;

namespace VideoManagementApi.Domain.Entities
{
    public class ProfilePicture : BaseEntity, IEntity
    {
        public string Title { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}