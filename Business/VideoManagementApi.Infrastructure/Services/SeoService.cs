using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VideoManagementApi.Application.Features.SeoFeatures.Commands;
using VideoManagementApi.Application.Interfaces.Services;
using VideoManagementApi.Domain.Common;
using VideoManagementApi.Domain.Entities;
using VideoManagementApi.Infrastructure.Context;
using VideoManagementApi.Infrastructure.Context.Configurations;

namespace VideoManagementApi.Infrastructure.Services;

public class SeoService : ISeoService
{
    private readonly ISeoRepository _seoRepository;
    private readonly VideoContext _videoContext;
    private readonly IMapper _mapper;

    public SeoService(ISeoRepository seoRepository, IMapper mapper, VideoContext videoContext)
    {
        _seoRepository = seoRepository;
        _mapper = mapper;
        _videoContext = videoContext;
    }

    public async Task<IResult> CreateAsync(CreateSeoCommand createSeoCommand, CancellationToken cancellationToken)
    {
        var video = await _videoContext
            .Videos
            .Include(a => a.Seos)
            .SingleOrDefaultAsync(a => a.Id == createSeoCommand.VideoId, cancellationToken);
        if (video == null)
            return await Result.FailAsync();
        var seo = _mapper.Map<Seo>(createSeoCommand);
        seo.Video = video;
        video.Seos.Add(seo);
        video.ModifiedDate = DateTime.Now;
        await _seoRepository.AddAsync(seo, cancellationToken);
        await _videoContext.SaveChangesAsync(cancellationToken);
        return await Result.SuccessAsync();
    }

    public async Task<IResult> UpdateAsync(UpdateSeoCommand updateSeoCommand, CancellationToken cancellationToken)
    {
        var video = await _videoContext
            .Videos
            .Include(a => a.Seos)
            .SingleOrDefaultAsync(a => a.Id == updateSeoCommand.VideoId, cancellationToken);
        if (video == null)
            return await Result.FailAsync();
        var seo = _mapper.Map<Seo>(updateSeoCommand);
        seo.Video = video;
        var oldSeo = video.Seos.SingleOrDefault(a => a.Id == seo.Id);
        if (oldSeo != null)
            video.Seos.Remove(oldSeo);
        await _seoRepository.AddAsync(seo, cancellationToken);

        video.Seos.Add(seo);
        await _videoContext.SaveChangesAsync(cancellationToken);
        return await Result.SuccessAsync();
    }

    public async Task<IResult<List<Seo>>> GetSeosByVideoIdAsync(int videoId, CancellationToken cancellationToken)
    {
        var video = await _videoContext
            .Videos
            .Include(a => a.Seos)
            .SingleOrDefaultAsync(a => a.Id == videoId, cancellationToken);
        if (video == null)
            return await Result<List<Seo>>.FailAsync();
        return await Result<List<Seo>>.SuccessAsync(video.Seos.ToList());
    }
}