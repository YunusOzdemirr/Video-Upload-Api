using Microsoft.EntityFrameworkCore;
using VideoManagementApi.DataAccess.Mappings;
using VideoManagementApi.Models;

namespace VideoManagementApi.DataAccess.EntityFramework;

public class VideoContext : DbContext
{
    public DbSet<Video> Videos { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Advertisement> Advertisements { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<VideoAndCategory> VideoAndCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
        modelBuilder.ApplyConfiguration(new LikeConfiguration());
        modelBuilder.ApplyConfiguration(new VideoConfiguration());
        modelBuilder.ApplyConfiguration(new SeoConfiguration());
        modelBuilder.ApplyConfiguration(new AdvertisementConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new VideoAndCategoryConfiguration());
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("");
        base.OnConfiguring(optionsBuilder);
    }
}