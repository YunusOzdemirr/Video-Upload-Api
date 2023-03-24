namespace VideoManagementApi.Dtos.CommentDtos;

public abstract class CommentDto
{
    public int Id { get; set; }
    public string IpAddress { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }
    public int VideoId { get; set; }
}