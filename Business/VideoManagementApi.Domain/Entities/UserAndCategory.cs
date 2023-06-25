namespace VideoManagementApi.Domain.Entities;

public class UserAndCategory
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}