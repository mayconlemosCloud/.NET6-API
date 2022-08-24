using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class Contexto : DbContext
    {
        public Contexto()
        {
        }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
    }
}