using System;
using MediatR;
using VideoManagementApi.Application.Interfaces.Context;
using VideoManagementApi.Domain.Common;
using VideoManagementApi.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using VideoManagementApi.Domain.Entities;
using VideoManagementApi.Infrastructure.Context.Configurations;

namespace VideoManagementApi.Infrastructure.Context
{
    public class VideoContext : DbContext, IApplicationDbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "videoContext";
        private readonly IMediator _mediator;

        public DbSet<Video> Videos { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<VideoAndCategory> VideoAndCategories { get; set; }

        //public DbSet<User> Users { get; set; }

        public VideoContext()
        {
        }

        public VideoContext(DbContextOptions<VideoContext> options, IMediator mediator)
            : base(options) => _mediator = mediator;

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
            optionsBuilder.UseSqlServer("Server=localhost;Database=VideoContext;User=sa;Password=bhdKs3WOp7;");

            base.OnConfiguring(optionsBuilder);
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEventsAsync(this);
            await base.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}