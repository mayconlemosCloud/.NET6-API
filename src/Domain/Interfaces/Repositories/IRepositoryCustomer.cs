using Application.DTOs;
using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IRepositoryCustomer
    {
        void Add(CustomerDTO obj);

        Task Delete(int id);

        Task Update(Customer obj);

        Task<IEnumerable<Customer>> GetAll();

        Task<Customer> GetById(int id);
    }
}