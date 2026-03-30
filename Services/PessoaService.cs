
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
        public async Task<Pessoa> CriarPessoaAleatoriaAsync(Tipo tipo)
        {
            if (tipo == Tipo.Fisica)
            {
                var pessoaFisica = Helpers.CriarFisica();
                await _repo.CriarPessoaAleatoriaFisicaAsync(pessoaFisica);
                return pessoaFisica;
            }
            if (tipo == Tipo.Juridica)
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
        
        public async Task<List<Pessoa>> GetPessoaAleatoriaAsync(int page, int pageSize)
        {
            var result = await _repo.GetPessoaAleatoriaAsync(page, pageSize, Tipo.Fisica);
            return result.Items;
        }  

        public async Task<Pessoa> GetPessoaAleatoriaTipoAsync(Tipo tipo)
        {
            if (tipo == Tipo.Fisica)
            {
                return await _repo.GetPessoaAleatoriaFisicaAsync(Tipo.Fisica);
            }
            if (tipo == Tipo.Juridica)
            {
                return await _repo.GetPessoaAleatoriaJuridicaAsync(Tipo.Juridica);
            }
            return null;
        }

        public async Task<Pessoa> GetPessoaByIdAsync(int id)
        {
            return await _repo.GetPessoaByIdAsync(id);
        }
        

    }
}