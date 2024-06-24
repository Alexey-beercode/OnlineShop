using System.Collections;
using Mapster;
using MapsterMapper;
using OnlineShop.BLL.DTO.Requests;
using OnlineShop.BLL.DTO.Responses;
using OnlineShop.BLL.Exceptions;
using OnlineShop.BLL.Services.Interfaces;
using OnlineShop.DAL.Entities.Implementations;
using OnlineShop.DAL.Repositories.Implementations;

namespace OnlineShop.BLL.Services.Implementations;

public class ProductService:IProductService
{
    private readonly ProductRepository _productRepository;
    private readonly CategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public ProductService(ProductRepository productRepository, CategoryRepository categoryRepository, IMapper mapper)
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
        var newProduct = _mapper.Map<Product>(productRequestDto);
        await _productRepository.UpdateAsync(newProduct, cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(id, cancellationToken)??throw new EntityNotFoundException("Product",id);
        await _productRepository.DeleteAsync(product, cancellationToken);
    }

    public async Task<ProductsCollectionResponseDTO> GetAllAsync(CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync(cancellationToken);

        if (products == null || !products.Any())
        {
            return new ProductsCollectionResponseDTO { Products = new List<ProductResponseDTO>() };
        }

        var productResponseDTOs = _mapper.Map<IEnumerable<ProductResponseDTO>>(products);
        return new ProductsCollectionResponseDTO { Products = productResponseDTOs };
    }

    public async Task<ProductResponseDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(id, cancellationToken)??throw new EntityNotFoundException("Product",id);
        return product.Adapt<ProductResponseDTO>();

    }

    public async Task<ProductsCollectionResponseDTO> GetByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryId) ?? throw new EntityNotFoundException("Category not found");
        var productsByCategory = await _productRepository.GetByCategoryIdAsync(categoryId, cancellationToken);
        var productResponseDTOs = _mapper.Map<IEnumerable<ProductResponseDTO>>(productsByCategory);
        return new ProductsCollectionResponseDTO { Products = productResponseDTOs };
    }
}