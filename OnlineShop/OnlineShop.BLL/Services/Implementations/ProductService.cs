using System.Collections;
using Mapster;
using MapsterMapper;
using OnlineShop.BLL.DTO.Requests;
using OnlineShop.BLL.DTO.Responses;
using OnlineShop.BLL.Exceptions;
using OnlineShop.BLL.Services.Interfaces;
using OnlineShop.DAL.Entities.Implementations;
using OnlineShop.DAL.Repositories.Implementations;
using OnlineShop.DAL.Repositories.Interfaces;

namespace OnlineShop.BLL.Services.Implementations;

public class ProductService:IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(ProductRequestDTO productRequestDto,CancellationToken cancellationToken = default)
    {
        var category = await _categoryRepository.GetByIdAsync(productRequestDto.CategoryId) ?? throw new EntityNotFoundException("Category not found");
        var product = _mapper.Map<Product>(productRequestDto);
        await _productRepository.CreateAsync(product,cancellationToken);
    }
    
    public async Task UpdateAsync(ProductUpdateRequestDTO productRequestDto, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(productRequestDto.Id, cancellationToken)??throw new EntityNotFoundException("Product",productRequestDto.Id);
        var category = await _categoryRepository.GetByIdAsync(productRequestDto.CategoryId) ?? throw new EntityNotFoundException("Category not found");
        _mapper.Map<Product>(productRequestDto);
        product.CategoryId = productRequestDto.CategoryId;

        await _productRepository.UpdateAsync(product, cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(id, cancellationToken)??throw new EntityNotFoundException("Product",id);
        await _productRepository.DeleteAsync(product, cancellationToken);
    }

    public async Task<IEnumerable<ProductResponseDTO>> GetAllAsync(CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync(cancellationToken);

        var productResponseDTOs = new List<ProductResponseDTO>();
        foreach (var product in products)
        {
            productResponseDTOs.Add(_mapper.Map<ProductResponseDTO>(product));
        }

        return productResponseDTOs;
    }

    public async Task<ProductResponseDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(id, cancellationToken)??throw new EntityNotFoundException("Product",id);
        return product.Adapt<ProductResponseDTO>();

    }

    public async Task<IEnumerable<ProductResponseDTO>> GetByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryId) ?? throw new EntityNotFoundException("Category not found");
        var productsByCategory = await _productRepository.GetByCategoryIdAsync(categoryId, cancellationToken);
        var productResponseDTOs = new List<ProductResponseDTO>();
        foreach (var product in productsByCategory)
        {
            productResponseDTOs.Add(_mapper.Map<ProductResponseDTO>(product));
        }

        return productResponseDTOs;
    }
}