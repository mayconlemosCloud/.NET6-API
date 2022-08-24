using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class Contexto : DbContext
    {
        public Contexto()
        {
        }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          => optionsBuilder.UseNpgsql("Host=ec2-100-25-72-111.compute-1.amazonaws.com;Database=d6mu5pjnvhmt3t;Username=dxgerfcrjrwiew;Password=3ea47a9101db1ec89aeb25b26c58f082a3775199cbe3feb67bcce30c424d6f81");
        public DbSet<Client> Client { get; set; }
    }
}