using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.BLL.DTO.Requests;
using OnlineShop.BLL.Services.Interfaces;

namespace OnlineShop.Controllers;

[Route("/api/product")]
[ApiController]
public class ProductController:Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var product = await _productService.GetByIdAsync(id, default);
        return Ok(product);
    }
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var products = await _productService.GetAllAsync(default);
        return Ok(products);
    }

    [HttpGet("get-by-category/{categoryId}")]
    public async Task<IActionResult> GetByCategoryIdAsync(Guid categoryId)
    {
        var products = await _productService.GetByCategoryIdAsync(categoryId, default);
        return Ok(products);
    }

    [Authorize]
    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync([FromBody]ProductRequestDTO productRequestDto)
    {
        await _productService.CreateAsync(productRequestDto, default);
        return Ok();
    }

    [Authorize]
    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync([FromBody]ProductUpdateRequestDTO productUpdateRequestDto)
    {
        await _productService.UpdateAsync(productUpdateRequestDto, default);
        return Ok();
    }

    [Authorize]
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _productService.DeleteAsync(id, default);
        return Ok();
    }
}