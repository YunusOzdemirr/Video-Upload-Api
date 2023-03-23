using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoManagementApi.Models;

namespace VideoManagementApi.DataAccess.Mappings;

public class VideoConfiguration : IEntityTypeConfiguration<Video>
{
    public void Configure(EntityTypeBuilder<Video> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Title).HasMaxLength(100);
        builder.Property(a => a.FileName).HasMaxLength(100);
        builder.Property(a => a.FilePath).HasMaxLength(100);
        builder.Property(a => a.Description).HasMaxLength(1000);
        builder.Property(a => a.WatchCount);

        builder.ToTable("Videos");
    }
}