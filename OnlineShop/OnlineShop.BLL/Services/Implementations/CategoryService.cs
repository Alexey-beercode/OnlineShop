using Mapster;
using MapsterMapper;
using OnlineShop.BLL.DTO.Response;
using OnlineShop.BLL.DTO.Responses;
using OnlineShop.BLL.Exceptions;
using OnlineShop.BLL.Services.Interfaces;
using OnlineShop.DAL.Entities.Implementations;
using OnlineShop.DAL.Repositories.Implementations;
using OnlineShop.DAL.Repositories.Interfaces;

namespace OnlineShop.BLL.Services.Implementations;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(string categoryName, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByNameAsync(categoryName);
        if (category!=null)
        {
            throw new Exception($"Category with name : {category.Name} is exists");
        }
        await _categoryRepository.CreateAsync(new Category() { Name = categoryName },cancellationToken);
    }

    public async Task<CategoriesCollectionResponseDTO> GetAllAsync(CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<CategoriesCollectionResponseDTO>(categories); 
    }

    public async Task<CategoryResponseDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(id, cancellationToken)?? throw new EntityNotFoundException("Category",id);
        return _mapper.Map<CategoryResponseDTO>(category);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(id, cancellationToken)?? throw new EntityNotFoundException("Category",id);
        await _categoryRepository.DeleteAsync(category, cancellationToken);
    }
}