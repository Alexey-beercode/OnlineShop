using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.BLL.DTO.Request;
using OnlineShop.BLL.Services.Interfaces;

namespace OnlineShop.Controllers;

[ApiController]
[Route("/api/user")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;
    
    public UserController(IUserService userService, ITokenService tokenService)
    {
        _userService = userService;
        _tokenService = tokenService;
    }

    [HttpGet("{id:guid}")]
    [Authorize]
    public async Task<IResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _userService.GetByIdAsync(id, cancellationToken);
        return TypedResults.Ok(user);
    }

    [HttpPost]
    public async Task<IResult> Login([FromBody] LoginRequestDTO request, CancellationToken cancellationToken = default)
    {
        var user = await _userService.LoginAsync(request, cancellationToken);

        var token = _tokenService.GenerateAccessToken(user);
        return TypedResults.Ok(token);
    }
    
    [HttpPost]
    public async Task<IResult> Register([FromBody] RegisterRequestDTO request, CancellationToken cancellationToken = default)
    {
        var user = await _userService.RegisterAsync(request, cancellationToken);

        var token = _tokenService.GenerateAccessToken(user);
        return TypedResults.Ok(token);
    }
}