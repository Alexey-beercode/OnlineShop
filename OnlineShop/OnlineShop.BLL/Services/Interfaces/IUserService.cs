using OnlineShop.BLL.DTO.Request;
using OnlineShop.BLL.DTO.Response;
using OnlineShop.DAL.Entities.Implementations;

namespace OnlineShop.BLL.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserResponseDTO>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<UserResponseDTO> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<User> LoginAsync(LoginRequestDTO loginRequestDTO, CancellationToken cancellationToken = default);
    Task<User> RegisterAsync(RegisterRequestDTO registerRequestDTO, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid userId, CancellationToken cancellationToken = default);
}