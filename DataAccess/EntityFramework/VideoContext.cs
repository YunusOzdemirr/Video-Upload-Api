using Microsoft.EntityFrameworkCore;
using VideoManagementApi.DataAccess.Mappings;
using VideoManagementApi.Models;

namespace VideoManagementApi.DataAccess.EntityFramework;

public class VideoContext : DbContext
{
    DbSet<Video> Videos { get; set; }
    DbSet<Comment> Comments { get; set; }
    DbSet<Like> Likes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
        modelBuilder.ApplyConfiguration(new LikeConfiguration());
        modelBuilder.ApplyConfiguration(new VideoConfiguration());
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("");
        base.OnConfiguring(optionsBuilder);
    }
}