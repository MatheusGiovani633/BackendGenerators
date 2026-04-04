namespace BackendGenerators.Repository
{
    using BackendGenerators.Data;
    using BackendGenerators.Models;
    using Microsoft.EntityFrameworkCore;
    using BackendGenerators.Enums;

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
        public async Task<List<Receita>> ProcurarReceitaAsync(Tipo tipo, string nome)
        {
            return await _db.Receitas
                .Include(r => r.Pessoa)
                .Where(r =>
                    tipo == Tipo.Fisica && r.Pessoa.Nome.Contains(nome) ||
                    tipo == Tipo.Juridica && r.Pessoa.Nome.Contains(nome)
                )
                .ToListAsync();
        }
    }

}
