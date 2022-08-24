using Application.DTOs;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Application.Services
{
    public class ServiceCustomer : IServiceCustomer
    {
        private readonly IRepositoryCustomer _repositoryCustomer;

        public ServiceCustomer(IRepositoryCustomer repositoryCustomer)
        {
            _repositoryCustomer = repositoryCustomer;
        }

        public void Add(CustomerDTO obj)
        {
            _repositoryCustomer.Add(obj);
        }

        public async Task Delete(int id)
        {
            await _repositoryCustomer.Delete(id);
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _repositoryCustomer.GetAll();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Customer obj)
        {
            await _repositoryCustomer.Update(obj);
        }
    }
}