using AutoMapper;
using VideoManagementApi.Application.Features.CategoryFeatures.Commands;
using VideoManagementApi.Application.Features.CategoryFeatures.Queries;
using VideoManagementApi.Application.Interfaces.Services;
using VideoManagementApi.Domain.Common;
using VideoManagementApi.Domain.Entities;
using VideoManagementApi.Infrastructure.Utilities;

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
        var result = await FileUpload.UploadAlternative(createCategoryCommand.File, "Categories", "");
        if (!result.Succeeded)
            return await Result<int>.FailAsync();
        category.FileName = result.Message;
        category.FilePath = result.Data as string;
        await _repository.AddAsync(category, cancellationToken);
        return await Result.SuccessAsync();
    }

    public async Task<IResult> UpdateAsync(UpdateCategoryCommand updateCategoryCommand,
        CancellationToken cancellationToken)
    {
        var categoryExist =
            await _repository.GetByIdAsync(updateCategoryCommand.Id, cancellationToken);
        if (categoryExist == null)
            return await Result.FailAsync();
        var newCategory = _mapper.Map<UpdateCategoryCommand, Category>(updateCategoryCommand, categoryExist);
        var result = await FileUpload.UploadAlternative(updateCategoryCommand.File, "Categories", "");
        if (!result.Succeeded)
            return await Result<int>.FailAsync();
        newCategory.FileName = result.Message;
        newCategory.FilePath = result.Data as string;
        await _repository.UpdateAsync(newCategory, cancellationToken);
        return await Result.SuccessAsync();
    }

    public async Task<IResult<List<Category>>> GetAllAsync(GetCategoriesQuery getCategoriesQuery,
        CancellationToken cancellationToken)
    {
        var categories = await _repository.GetAllAsync(cancellationToken: cancellationToken);
        return await Result<List<Category>>.SuccessAsync(categories);
    }

    public async Task<IResult> AddCountAsync(AddCountCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (category == null)
            return await Result.FailAsync();
        category.ClickCount++;
        await _repository.UpdateAsync(category, cancellationToken);
        return await Result.SuccessAsync();
    }
}