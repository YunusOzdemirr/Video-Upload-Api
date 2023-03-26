using VideoManagementApi.Domain.Common;

namespace VideoManagementApi.Domain.Entities;

public abstract class Like : BaseEntity
{
    public string IpAddress { get; set; }
    public bool IsLiked { get; set; }
    public int VideoId { get; set; }
    public Video Video { get; set; }
}