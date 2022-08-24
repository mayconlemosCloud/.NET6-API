using Domain.Interfaces.Repositories;
using Domain.Models;

namespace Infra.Repositorys
{
    public class RepositoryUser : IRepositoryUser
    {
        public User Get(string email, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Email = "maycon", Password = "123", Role = "manager" });
            users.Add(new User { Id = 2, Email = "robin", Password = "robin", Role = "employee" });
            return users.Where(x => x.Email.ToLower() == email.ToLower() && x.Password == password).FirstOrDefault();
        }
    }
}