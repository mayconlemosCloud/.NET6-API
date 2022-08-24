using Application.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositorys
{
    public class RepositoryClient : IRepositoryClient
    {
        private readonly Contexto dbContext;

        public RepositoryClient(Contexto dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Client obj)
        {
            try
            {
                dbContext.Set<Client>().Add(obj);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Client obj)
        {
            try
            {
                dbContext.Set<Client>().Remove(obj);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            var response = await dbContext.Client.ToListAsync();
            return response;
        }

        public Client GetById(int id)
        {
            return dbContext.Set<Client>().Find(id);
        }
    }
}