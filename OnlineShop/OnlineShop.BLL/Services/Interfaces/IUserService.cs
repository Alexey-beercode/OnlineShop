using OnlineShop.BLL.DTO.Request;
using OnlineShop.BLL.DTO.Response;

namespace OnlineShop.BLL.Services.Interfaces;

public interface IUserService
{
    Task<UserResponseDTO> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task LoginAsync(LoginRequestDTO loginRequestDTO, CancellationToken cancellationToken = default);
    Task RegisterAsync(RegisterRequestDTO registerRequestDTO, CancellationToken cancellationToken = default);
}