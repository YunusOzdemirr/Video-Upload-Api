namespace VideoManagementApi.Models;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public string FilePath { get; set; }
    public string FileName { get; set; }
    public ICollection<VideoAndCategory> VideoAndCategories { get; set; }
}