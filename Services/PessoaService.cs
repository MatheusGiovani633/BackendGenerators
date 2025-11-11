
namespace BackendGenerators.Services
{
    using BackendGenerators.Repository;
    using BackendGenerators.Helpers;
    using BackendGenerators.Models;
    public class PessoaService : IPessoaService
    {
        private readonly PessoaRepository _repo;

        public PessoaService(PessoaRepository repo)
        {
            _repo = repo;
        }

        public async Task<Pessoa> CriarPessoaAleatoriaAsync(string tipo)
        {
            if (tipo == null)
            {
                throw new ArgumentNullException("Tipo não pode ser nulo");
            }
            if (string.Equals(tipo, "fisica", StringComparison.OrdinalIgnoreCase) || string.Equals(tipo, "Fisica", StringComparison.OrdinalIgnoreCase))
            {
                var pessoaFisica = Helpers.CriarFisica();
                await _repo.CriarPessoaAleatoriaFisicaAsync(pessoaFisica);
                return pessoaFisica;
            }
            if (string.Equals(tipo, "juridica", StringComparison.OrdinalIgnoreCase) || string.Equals(tipo, "Juridica", StringComparison.OrdinalIgnoreCase))
            {
                var pessoaJuridica = Helpers.CriarJuridica();
                await _repo.CriarPessoaAleatoriaJuridicaAsync(pessoaJuridica);
                return pessoaJuridica;

            }
            return null;
        }
        
        public async Task<Medico> CriarMedicoAleatorioAsync()
        {
            var pessoaFisica = Helpers.CriarFisica();
            var pessoaSalva = await _repo.CriarPessoaAleatoriaFisicaAsync(pessoaFisica);

            var medico = new Medico
            {
                Cod_Pessoa = pessoaSalva.Cod_Pessoa,
                CRM = new Random().Next(10000, 99999),
            };
            return await _repo.CriarMedicoAleatorioAsync(medico);
        }
        public async Task<List<Medico>> GetMedicoAleatorioAsync()
        {
            return await _repo.GetMedicoAleatorioAsync();
        }
        
        public async Task<List<Pessoa>> GetPessoaAleatoriaAsync()
        {
            return await _repo.GetPessoaAleatoriaAsync();
        }  

        public async Task<Pessoa> GetPessoaAleatoriaTipoAsync(string tipo)
        {
            if (string.Equals(tipo, "fisica", StringComparison.OrdinalIgnoreCase) || string.Equals(tipo, "Fisica", StringComparison.OrdinalIgnoreCase))
            {
                return await _repo.GetPessoaAleatoriaFisicaAsync(tipo);
            }
            if (string.Equals(tipo, "juridica", StringComparison.OrdinalIgnoreCase) || string.Equals(tipo, "Juridica", StringComparison.OrdinalIgnoreCase))
            {
                return await _repo.GetPessoaAleatoriaJuridicaAsync(tipo);
            }
            return null;
        }

        public async Task<Pessoa> GetPessoaByIdAsync(int id)
        {
            return await _repo.GetPessoaByIdAsync(id);
        }

    }
}