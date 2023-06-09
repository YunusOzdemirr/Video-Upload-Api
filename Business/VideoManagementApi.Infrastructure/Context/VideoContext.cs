﻿using System;
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
        public DbSet<Seo> Seos { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<VideoAndCategory> VideoAndCategories { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<User> Users { get; set; }

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
            modelBuilder.ApplyConfiguration(new ReportConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=localhost;Database=VideoContext;User=sa;Password=bhdKs3WOp7;");
            //optionsBuilder.UseSqlServer("Server=tcp:videomanagement-server-dev.database.windows.net,1433;Initial Catalog=videomanagement-db-dev;Persist Security Info=False;User ID=yunus;Password=jkyhtGLposr!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            //optionsBuilder.UseSqlServer("Server=videomanagement-dev.cnq05g1alpmq.eu-central-1.rds.amazonaws.com,1433;Initial Catalog=videomanagement-db-dev;Persist Security Info=False;User ID=admin;Password=jkyhtGLposr!;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=15;");
            optionsBuilder.UseSqlServer("Server=tcp:videomanagement-server-dev.database.windows.net,1433;Initial Catalog=videomanagement-db-dev;Persist Security Info=False;User ID=yunus;Password=jkyhtGLposr!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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