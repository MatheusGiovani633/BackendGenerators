using Microsoft.EntityFrameworkCore;
using BackendGenerators.Models;
namespace BackendGenerators.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<OrdemServicoCaixa> OrdemServicoCaixa { get; set; }
        
    }
}