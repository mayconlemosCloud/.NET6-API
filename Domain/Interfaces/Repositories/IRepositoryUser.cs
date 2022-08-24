using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IRepositoryUser
    {
        User Get(string email, string password);
    }
}