using VideoManagementApi.Domain.Common;

namespace VideoManagementApi.Domain.Entities;

public class VideoAndCategory : BaseEntity
{
    public int VideoId { get; set; }
    public Video Video { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}