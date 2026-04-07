namespace BackendGenerators.Repository
{
    using BackendGenerators.Data;
    using BackendGenerators.Models;
    using Microsoft.EntityFrameworkCore;
    using BackendGenerators.Enums;
    public class PessoaRepository
    {
        private readonly AppDbContext _db;

        public PessoaRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Pessoa> CriarPessoaAleatoriaFisicaAsync(Pessoa pessoas)
        {
            _db.Pessoas.Add(pessoas);
            await _db.SaveChangesAsync();
            return pessoas;
        }
        public async Task<Pessoa> CriarPessoaAleatoriaJuridicaAsync(Pessoa pessoas)
        {
            _db.Pessoas.Add(pessoas);
            await _db.SaveChangesAsync();
            return pessoas;
        }
        public async Task<Receita> CriarReceitaAleatoriaAsync(Receita receita)
        {
            _db.Receitas.Add(receita);
            await _db.SaveChangesAsync();
            return receita;
        }
        public async Task<Medico> CriarMedicoAleatorioAsync(Medico medico)
        {
            _db.Medico.Add(medico);
            await _db.SaveChangesAsync();

            return await _db.Medico
                .Include(m => m.Pessoa)
                .FirstOrDefaultAsync(m => m.Cod_Medico == medico.Cod_Medico);
        }
        public async Task<(List<Pessoa> Items, int TotalItems)> GetPessoaAleatoriaAsync(int page, int pageSize, Tipo tipo)
        { 
            var query = _db.Pessoas
                .AsNoTracking();

            var totalItems = await query.CountAsync();

            var items = await query
                .OrderBy(p => p.Cod_Pessoa)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalItems);
        }
        
        public async Task<List<Medico>> GetMedicoAleatorioAsync()
        {
            return await _db.Medico
                .Include(m => m.Pessoa)
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<List<Medico>> GetMedicoByIdAsync(int id)
        {
            return await _db.Medico
                .Include(m => m.Pessoa)
                .AsNoTracking()
                .Where(m => m.Pessoa.Identificador == id)
                .ToListAsync();
        }
        public async Task<Pessoa> GetPessoaAleatoriaFisicaAsync(Tipo tipo)
        {
            return await _db.Pessoas
                .Where(p => p.Cpf != null)
                .AsNoTracking()
                .OrderBy(p => EF.Functions.Random())
                .FirstOrDefaultAsync();
        }
        public async Task<Pessoa> GetPessoaAleatoriaJuridicaAsync(Tipo tipo)
        {
            return await _db.Pessoas
                .Where(p => p.Cnpj != null)
                .AsNoTracking()
                .OrderBy(p => EF.Functions.Random())
                .FirstOrDefaultAsync();
        }
        public async Task<Pessoa> GetPessoaByIdAsync(int id)
        {
            return await _db.Pessoas.AsNoTracking().FirstOrDefaultAsync(p => p.Identificador == id);
        }

    }
}