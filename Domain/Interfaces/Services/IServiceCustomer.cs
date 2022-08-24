using Application.DTOs;
using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface IServiceCustomer
    {
        void Add(CustomerDTO obj);

        Task Delete(int id);

        Task Update(Customer obj);

        Task<IEnumerable<Customer>> GetAll();

        Customer GetById(int id);
    }
}