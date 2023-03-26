using AutoMapper;
using VideoManagementApi.Application.Features.CategoryFeatures.Commands;
using VideoManagementApi.Application.Features.CategoryFeatures.Queries;
using VideoManagementApi.Application.Interfaces.Services;
using VideoManagementApi.Domain.Common;
using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Infrastructure.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IResult> CreateAsync(CreateCategoryCommand createCategoryCommand,
        CancellationToken cancellationToken)
    {
        var categoryExist =
            await _repository.GetByFilterAsync(a => a.Name == createCategoryCommand.Name, cancellationToken);
        if (categoryExist != null)
            return await Result.FailAsync();
        var category = _mapper.Map<Category>(createCategoryCommand);
        await _repository.AddAsync(category, cancellationToken);
        return await Result.SuccessAsync();
    }

    public async Task<IResult<List<Category>>> GetAllAsync(GetCategoriesQuery getCategoriesQuery,
        CancellationToken cancellationToken)
    {
        var categories = await _repository.GetAllAsync(cancellationToken: cancellationToken);
        return await Result<List<Category>>.SuccessAsync(categories);
    }
}