namespace VideoManagementApi.Models;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifyDate { get; set; }
    public int ModifiedBy { get; set; }
}