using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.BLL.DTO.Request;
using OnlineShop.BLL.DTO.Requests;
using OnlineShop.BLL.DTO.Responses;
using OnlineShop.BLL.Services.Interfaces;
using OnlineShop.DAL.Infrastructure;

namespace OnlineShop.Controllers;

[ApiController]
[Route("/api/order-items")]
public class OrderItemController(
    IOrderItemService _service): ControllerBase
{
    [HttpGet("{id:guid}")]
    //[Authorize]
    public async Task<IResult> GetById([FromRoute] Guid id, CancellationToken token)
    {
        return TypedResults.Ok(await _service.GetByIdAsync(id, token));
    }

    [HttpGet]
    //[Authorize]
    public async Task<IResult> GetAllAsync(CancellationToken token)
    {
        return TypedResults.Ok(await _service.GetAllAsync(token));
    }

    [HttpPost]
    //[Authorize]
    public async Task<IResult> CreateUser([FromBody] OrderItemRequestDTO request, CancellationToken token)
    {
        await _service.CreateOrderItemAsync(request, token);
        return TypedResults.Ok();
    }

    [HttpPut("{id:guid}")]
    //[Authorize]
    public async Task<IResult> UpdateUser([FromBody] OrderItemRequestDTO request, CancellationToken token)
    {
        await _service.UpdateOrderItemAsync(request, token);
        return TypedResults.Ok();
    }

    [HttpDelete("{id:guid}")]
    //[Authorize]
    public async Task<IResult> DeleteUser([FromRoute] Guid id, CancellationToken token)
    {
        await _service.DeleteOrderItemAsync(id, token);
        return TypedResults.NoContent();
    }
}
