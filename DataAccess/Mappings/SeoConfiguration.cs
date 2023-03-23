using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoManagementApi.Models;

namespace VideoManagementApi.DataAccess.Mappings;

public class SeoConfiguration : IEntityTypeConfiguration<Seo>
{
    public void Configure(EntityTypeBuilder<Seo> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Tag).IsRequired();
        builder.Property(a => a.Description).IsRequired();
        builder.HasOne<Video>(a => a.Video).WithMany(a => a.Seos).HasForeignKey(a => a.VideoId);
        builder.ToTable("Seos");
    }
}