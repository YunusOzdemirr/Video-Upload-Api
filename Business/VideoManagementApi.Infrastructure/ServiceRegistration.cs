using VideoManagementApi.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VideoManagementApi.Application.Interfaces.Services;
using VideoManagementApi.Infrastructure.Repositories;
using VideoManagementApi.Infrastructure.Services;

namespace VideoManagementApi.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddAInfrastructureRegistration(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<VideoContext>(opt =>
        {
            opt.UseSqlServer(configuration["VideoConnectionString"]);
            opt.EnableSensitiveDataLogging();
        });

        #region Repositories
        services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
        services.AddScoped<ICategoryRepository,CategoryRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<ILikeRepository,LikeRepository>();
        services.AddScoped<ISeoRepository, SeoRepository>();
        services.AddScoped<IVideoRepository, VideoRepository>();
        services.AddScoped<IVideoAndCategoryRepository, VideoAndCategoryRepository>();
        #endregion

        #region Services
        services.AddScoped<IAdvertisementService, AdvertisementService>();
        services.AddScoped<ICategoryService,CategoryService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<ILikeService,LikeService>();
        services.AddScoped<ISeoService, SeoService>();
        services.AddScoped<IVideoService, VideoService>();
        services.AddScoped<IVideoAndCategoryService, VideoAndCategoryService>();
        #endregion
        
        var optionsBuilder = new DbContextOptionsBuilder<VideoContext>()
            .UseSqlServer(configuration["VideoConnectionString"]);

        using var dbContext = new VideoContext(optionsBuilder.Options, null);
        //dbContext.Database.EnsureCreated();
        //dbContext.Database.Migrate();

        return services;
    }
}