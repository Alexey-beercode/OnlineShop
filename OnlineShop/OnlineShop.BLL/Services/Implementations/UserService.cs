using FluentValidation;
using Mapster;
using OnlineShop.BLL.DTO.Request;
using OnlineShop.BLL.DTO.Response;
using OnlineShop.BLL.Exceptions;
using OnlineShop.BLL.Helpers;
using OnlineShop.BLL.Mappers;
using OnlineShop.BLL.Services.Interfaces;
using OnlineShop.BLL.Validators;
using OnlineShop.DAL.Entities.Implementations;
using OnlineShop.DAL.Repositories.Interfaces;

namespace OnlineShop.BLL.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        MapsterConfig.Configure();
        
        _userRepository = userRepository;
    }

    public async Task<UserResponseDTO> GetByIdAsync(string userId, CancellationToken cancellationToken = default)
    {
        var id = userId.Adapt<Guid>();

        var user = await _userRepository.GetByIdAsync(id, cancellationToken);
        if (user is null)
        {
            throw new EntityNotFoundException(nameof(User), id);
        }

        var userResponseDTO = user.Adapt<UserResponseDTO>();

        return userResponseDTO;
    }

    public async Task LoginAsync(LoginRequestDTO loginRequestDTO, CancellationToken cancellationToken = default)
    {
        LoginValidator loginValidator = new LoginValidator();
        await loginValidator.ValidateAndThrowAsync(loginRequestDTO, cancellationToken);

        var user = await _userRepository.GetByLoginAsync(loginRequestDTO.Login, cancellationToken);
        if (user is null)
        {
            throw new AuthenticationException("Login or password entered incorrectly.");
        }

        if(!PasswordHelper.VerifyPassword(user.PasswordHash, loginRequestDTO.Password))
        {
            throw new AuthenticationException("Login or password entered incorrectly.");
        }
    }

    public async Task RegisterAsync(RegisterRequestDTO registerRequestDTO, CancellationToken cancellationToken = default)
    {
        RegisterValidator registerValidator = new RegisterValidator();
        await registerValidator.ValidateAndThrowAsync(registerRequestDTO, cancellationToken);
        
        var user = await _userRepository.GetByLoginAsync(registerRequestDTO.Login, cancellationToken);
        if (user is not null)
        {
            throw new AuthenticationException("This login is already in use.");
        }

        user = registerRequestDTO.Adapt<User>();

        await _userRepository.CreateAsync(user, cancellationToken);
    }
}