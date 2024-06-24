using System.Security.Claims;
using OnlineShop.DAL.Entities.Implementations;

namespace OnlineShop.BLL.Services.Interfaces;

public interface ITokenService
{
    string GenerateAccessToken(User user);
}