using OnlineShop.BLL.DTO.Request;
using OnlineShop.BLL.DTO.Response;
using OnlineShop.DAL.Entities.Implementations;

namespace OnlineShop.BLL.Services.Interfaces;

public interface IUserService
{
    Task<UserResponseDTO> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<User> LoginAsync(LoginRequestDTO loginRequestDTO, CancellationToken cancellationToken = default);
    Task<User> RegisterAsync(RegisterRequestDTO registerRequestDTO, CancellationToken cancellationToken = default);
}