using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Infrastructure.Context.Configurations;

public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
{
    public void Configure(EntityTypeBuilder<Advertisement> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Name).IsRequired(false);
        builder.Property(a => a.Description).IsRequired(false);
        builder.Property(a => a.Orginator).IsRequired(false);
        builder.Property(a => a.OrginatorPhone).IsRequired(false);
        builder.Property(a => a.Url).IsRequired(false);
        builder.Property(a => a.FileName).IsRequired(false);
        builder.Property(a => a.FilePath).IsRequired(false);
        builder.ToTable("Advertisements");
    }
}