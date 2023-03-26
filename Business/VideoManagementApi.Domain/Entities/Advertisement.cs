using VideoManagementApi.Domain.Common;

namespace VideoManagementApi.Domain.Entities;

public  class Advertisement : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string FilePath { get; set; }
    public string FileName { get; set; }
    public string Url { get; set; }
    public int WatchCount { get; set; }
    public int ClickCount { get; set; }
    public int Rank { get; set; }
}