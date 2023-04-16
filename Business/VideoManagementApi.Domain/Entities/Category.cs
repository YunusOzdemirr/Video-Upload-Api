using VideoManagementApi.Domain.Common;

namespace VideoManagementApi.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public string FilePath { get; set; }
    public string FileName { get; set; }
    public int ClickCount { get; set; }
    public ICollection<VideoAndCategory> VideoAndCategories { get; set; }
}