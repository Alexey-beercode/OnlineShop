using Microsoft.AspNetCore.Mvc;
using OnlineShop.BLL.DTO.Request;
using OnlineShop.BLL.Services.Interfaces;

namespace OnlineShop.Controllers
{
    [ApiController]
    [Route("/api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet("{id:guid}")]
        //[Authorize]
        public async Task<IResult> GetById([FromRoute] Guid id, CancellationToken token)
        {
            return TypedResults.Ok(await _service.GetOrderByIdAsync(id, token));
        }

        [HttpGet]
        //[Authorize]
        public async Task<IResult> GetAllAsync(CancellationToken token)
        {
            return TypedResults.Ok(await _service.GetAllAsync(token));
        }

        [HttpPost]
        //[Authorize]
        public async Task<IResult> CreateOrder([FromBody] CreateOrderRequestDTO request, CancellationToken token)
        {
            var orderResponseDTO = await _service.CreateOrderAsync(request, token);
            return TypedResults.Created($"/api/orders/{orderResponseDTO.Id}", orderResponseDTO);
        }

        [HttpPut("{id:guid}")]
        //[Authorize]
        public async Task<IResult> UpdateOrder([FromRoute] Guid id, [FromBody] UpdateOrderRequestDTO request, CancellationToken token)
        {
            await _service.UpdateOrderAsync(id, request, token);
            return TypedResults.Ok();
        }

        [HttpDelete("{id:guid}")]
        //[Authorize]
        public async Task<IResult> DeleteOrder([FromRoute] Guid id, CancellationToken token)
        {
            await _service.DeleteOrderAsync(id, token);
            return TypedResults.NoContent();
        }
    }
}
