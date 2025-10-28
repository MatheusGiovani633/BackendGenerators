namespace BackendGenerators.Services 
{
    using BackendGenerators.Helpers;
    using BackendGenerators.Data;
    using BackendGenerators.Models;
    using Microsoft.EntityFrameworkCore;

    public class PessoaService : IPessoaService
    {
        private readonly AppDbContext _db;
        private static readonly Random _random = new();

        public PessoaService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Pessoa> CriarPessoaAleatoriaAsync(string tipo)
        {
            if (string.Equals(tipo, "fisica", StringComparison.OrdinalIgnoreCase) || string.Equals(tipo, "Fisica", StringComparison.OrdinalIgnoreCase))
            {
                var pessoa = Helpers.CriarFisica();
                _db.Pessoas.Add(pessoa);
                await _db.SaveChangesAsync();
                return pessoa;
            }
            if (string.Equals(tipo, "juridica", StringComparison.OrdinalIgnoreCase) || string.Equals(tipo, "Juridica", StringComparison.OrdinalIgnoreCase))
            {
                var pessoa = Helpers.CriarJuridica();
                _db.Pessoas.Add(pessoa);
                await _db.SaveChangesAsync();
                return pessoa;
            }
            return null;
        }

        public async Task<Pessoa> GetPessoaAleatoriaAsync(string tipo)
        {
            if (string.Equals(tipo, "fisica", StringComparison.OrdinalIgnoreCase))
            {
                return await _db.Pessoas
                    .Where(p => p.Cpf != null)
                    .OrderBy(p => EF.Functions.Random())
                    .FirstOrDefaultAsync();
            }
            if (string.Equals(tipo, "juridica", StringComparison.OrdinalIgnoreCase))
            {
                return await _db.Pessoas
                    .Where(p => p.Cnpj != null)
                    .OrderBy(p => EF.Functions.Random())
                    .FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<Pessoa> GetPessoaByIdAsync(int id)
        {
            return await _db.Pessoas.FindAsync(id);
        }

    }
}