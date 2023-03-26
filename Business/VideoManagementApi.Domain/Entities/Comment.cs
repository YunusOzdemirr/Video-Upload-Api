using VideoManagementApi.Domain.Common;

namespace VideoManagementApi.Domain.Entities;

public  class Comment : BaseEntity
{
    public string IpAddress { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }
    public bool IsApproved { get; set; }
    public int VideoId { get; set; }
    public Video Video { get; set; }
}