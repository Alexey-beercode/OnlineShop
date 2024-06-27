using MapsterMapper;
using OnlineShop.BLL.DTO.Request;
using OnlineShop.BLL.DTO.Response;
using OnlineShop.BLL.Exceptions;
using OnlineShop.BLL.Helpers;
using OnlineShop.BLL.Services.Interfaces;
using OnlineShop.DAL.Entities.Implementations;
using OnlineShop.DAL.Repositories.Interfaces;

namespace OnlineShop.BLL.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserResponseDTO>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<UserResponseDTO>>(users);
    }

    public async Task<UserResponseDTO> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);
        if (user is null)
        {
            throw new EntityNotFoundException(nameof(User), userId);
        }

        return _mapper.Map<UserResponseDTO>(user);
    }

    public async Task<User> LoginAsync(LoginRequestDTO loginRequestDTO, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByLoginAsync(loginRequestDTO.Login, cancellationToken);
        if (user is null)
        {
            throw new AuthenticationException("Login or password entered incorrectly.");
        }

        if(!PasswordHelper.VerifyPassword(user.PasswordHash, loginRequestDTO.Password))
        {
            throw new AuthenticationException("Login or password entered incorrectly.");
        }

        return user;
    }

    public async Task<User> RegisterAsync(RegisterRequestDTO registerRequestDTO, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByLoginAsync(registerRequestDTO.Login, cancellationToken);
        if (user is not null)
        {
            throw new AuthenticationException("This login is already in use.");
        }

        user = _mapper.Map<User>(registerRequestDTO);
        user.PasswordHash = PasswordHelper.HashPassword(registerRequestDTO.Password);

        await _userRepository.CreateAsync(user, cancellationToken);

        return user;
    }

    public async Task DeleteAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);
        if (user is null)
        {
            throw new EntityNotFoundException(nameof(User), userId);
        }

        await _userRepository.DeleteAsync(user, cancellationToken);
    }
}