using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface IServiceToken
    {
        string GenerateToken(User user);
    }
}