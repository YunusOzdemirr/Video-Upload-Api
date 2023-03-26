using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Infrastructure.Context.Configurations;

public class VideoAndCategoryConfiguration : IEntityTypeConfiguration<VideoAndCategory>
{
    public void Configure(EntityTypeBuilder<VideoAndCategory> builder)
    {
        builder.HasKey(a => new { a.VideoId, a.CategoryId });

        builder.HasOne<Video>(a => a.Video).WithMany(a => a.VideoAndCategories).HasForeignKey(a => a.CategoryId);
        builder.HasOne<Category>(a => a.Category).WithMany(a => a.VideoAndCategories).HasForeignKey(a => a.VideoId);
        builder.ToTable("VideoAndCategories");
    }
}