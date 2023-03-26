using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Infrastructure.Context.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Content).IsRequired();
        builder.Property(a => a.IpAddress).IsRequired();
        builder.Property(a => a.Name).IsRequired();

        builder.HasOne<Video>(a => a.Video).WithMany(a => a.Comments).HasForeignKey(a => a.VideoId);
        builder.ToTable("Comments");
    }
}