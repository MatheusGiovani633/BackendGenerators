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
        public DbSet<Medico> Medico { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Medico>()
                .HasOne(m => m.Pessoa)
                .WithOne(p => p.Medico)
                .HasForeignKey<Medico>(m => m.Cod_Pessoa);
        }
    }

}