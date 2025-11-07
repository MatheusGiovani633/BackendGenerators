namespace BackendGenerators.Repository
{
    using BackendGenerators.Data;
    using BackendGenerators.Models;
    using Microsoft.EntityFrameworkCore;

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
        public async Task<Medico> CriarMedicoAleatorioAsync(Medico medico)
        {
            _db.Medico.Add(medico);
            await _db.SaveChangesAsync();

            return await _db.Medico
                .Include(m => m.Pessoa)
                .FirstOrDefaultAsync(m => m.Cod_Medico == medico.Cod_Medico);
        }
        public async Task<List<Pessoa>> GetPessoaAleatoriaAsync()
        {
            return await _db.Pessoas.ToListAsync();
            
        }
        public async Task<Pessoa> GetPessoaAleatoriaFisicaAsync(string tipo)
        {
            return await _db.Pessoas
                .Where(p => p.Cpf != null)
                .OrderBy(p => EF.Functions.Random())
                .FirstOrDefaultAsync();
        }
        public async Task<Pessoa> GetPessoaAleatoriaJuridicaAsync(string tipo)
        {
            return await _db.Pessoas
                .Where(p => p.Cnpj != null)
                .OrderBy(p => EF.Functions.Random())
                .FirstOrDefaultAsync();
        }
        public async Task<Pessoa> GetPessoaByIdAsync(int id)
        {
            return await _db.Pessoas.FindAsync(id);
        }

    }
}