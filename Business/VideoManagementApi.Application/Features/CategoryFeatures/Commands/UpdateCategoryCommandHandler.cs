using VideoManagementApi.Domain.Entities;

namespace VideoManagementApi.Application.Features.CategoryFeatures.Commands;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, IResult>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request);
        var result = await _categoryRepository.UpdateAsync(category, cancellationToken);
        if (result)
            return await Result.SuccessAsync();
        else
            return await Result.FailAsync();
    }
}