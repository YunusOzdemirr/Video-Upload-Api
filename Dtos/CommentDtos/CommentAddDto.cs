namespace VideoManagementApi.Dtos.CommentDtos;

public abstract class CommentAddDto
{
    public string IpAddress { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }
    public int VideoId { get; set; }
}