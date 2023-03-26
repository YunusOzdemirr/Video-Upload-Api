using VideoManagementApi.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VideoManagementApi.Infrastructure.Repositories;

namespace VideoManagementApi.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddAInfrastructureRegistration(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<VideoContext>(opt =>
        {
            opt.UseSqlServer(configuration["MicroServiceConnectionString"]);
            opt.EnableSensitiveDataLogging();
        });

        // services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
        services.AddScoped<ICategoryRepository,CategoryRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<ILikeRepository,LikeRepository>();
        services.AddScoped<ISeoRepository, SeoRepository>();
        services.AddScoped<IVideoRepository, VideoRepository>();
        services.AddScoped<IVideoAndCategoryRepository, VideoAndCategoryRepository>();
        
        var optionsBuilder = new DbContextOptionsBuilder<VideoContext>()
            .UseSqlServer(configuration["MicroServiceConnectionString"]);

        using var dbContext = new VideoContext(optionsBuilder.Options, null);
        dbContext.Database.EnsureCreated();
        dbContext.Database.Migrate();

        return services;
    }
}