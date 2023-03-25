namespace VideoManagementApi.Models;

public class BaseEntity: IEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifyDate { get; set; }
    public int ModifiedBy { get; set; }
    public bool IsActive { get; set; }
}