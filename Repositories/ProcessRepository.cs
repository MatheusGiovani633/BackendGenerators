namespace BackendGenerators.Repository
{
    using BackendGenerators.Data;
    using BackendGenerators.Models;
    using Microsoft.EntityFrameworkCore;

    public class ProcessRepository
    {
  private readonly AppDbContext _db;

        public ProcessRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Receita> CriarReceitaAleatoriaAsync(Receita receita)
        {
            _db.Receitas.Add(receita);
            await _db.SaveChangesAsync();
            return receita;
        }
    }
    
}
