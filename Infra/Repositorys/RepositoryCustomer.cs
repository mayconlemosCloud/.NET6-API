using Application.DTOs;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorys
{
    public class RepositoryCustomer : IRepositoryCustomer
    {
        private readonly Contexto _dbContext;
        private readonly IMapper _mapper;

        public RepositoryCustomer(Contexto dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Add(CustomerDTO obj)
        {
            var customer = _mapper.Map<Customer>(obj);
            _dbContext.Customer.Add(customer);
            _dbContext.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var customer = await _dbContext.Customer.FirstOrDefaultAsync(it => it.Id == id);
            _dbContext.Customer.Remove(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _dbContext.Customer.ToListAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _dbContext.Customer.FirstOrDefaultAsync(it => it.Id == id);
        }

        public async Task Update(Customer obj)
        {
            _dbContext.Customer.Update(obj);
            await _dbContext.SaveChangesAsync();
        }
    }
}