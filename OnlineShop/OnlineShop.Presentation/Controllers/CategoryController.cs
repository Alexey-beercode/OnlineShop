using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.BLL.Services.Interfaces;

namespace OnlineShop.Controllers;

[Route("category")]
[ApiController]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var category = await _categoryService.GetByIdAsync(id,default);
        return Ok(category);
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var categories = await _categoryService.GetAllAsync(default);
        return Ok(categories);
    }
    
    [Authorize]
    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(string categoryName)
    {
        await _categoryService.CreateAsync(categoryName, default);
        return Ok();
    }

    [Authorize]
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _categoryService.DeleteAsync(id, default);
        return Ok();
    }
    
}