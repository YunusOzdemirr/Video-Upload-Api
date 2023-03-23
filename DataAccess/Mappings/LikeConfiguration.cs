using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoManagementApi.Models;

namespace VideoManagementApi.DataAccess.Mappings;

public class LikeConfiguration : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.IpAddress).IsRequired();
        builder.HasOne<Video>(a => a.Video).WithMany(a => a.Likes).HasForeignKey(a => a.VideoId);
        builder.ToTable("Likes");
    }
}