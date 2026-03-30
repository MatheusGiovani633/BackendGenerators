
namespace BackendGenerators.Services
{
    using BackendGenerators.Repository;
    using BackendGenerators.Helpers;
    using BackendGenerators.Models;
    using BackendGenerators.Enums;
    public class ProcessService : IProcessService
    {
        private readonly ProcessRepository _repo;

        public ProcessService(ProcessRepository repo)
        {
            _repo = repo;
        }
        public async Task<Receita> CriarReceitaAleatoriaAsync(int codPessoa, int codOrdemServicoCaixa, int codVendedor, int codMedico)
        {
            var receita = Helpers.CriarReceita(codPessoa, codOrdemServicoCaixa, codVendedor, codMedico);
            return await _repo.CriarReceitaAleatoriaAsync(receita);
        }
        public async Task<Receita> ProcurarReceitaAsync(Tipo tipo, string nome)
        {
            var receita = await _repo.ProcurarReceitaAsync(tipo, nome);
            if (receita == null)
            {     
                return await _repo.CriarReceitaAleatoriaAsync(receita);
            }
            if (receita.Pessoa == null)
            {
                throw new ArgumentException("Não há pessoas cadastrasdas para esse tipo de operação, utilizar o endpoint /pessoas");
            }
            if (!Enum.IsDefined(typeof(Tipo), tipo))
            {
                throw new ArgumentException("Tipo é obrigatório e deve ser válido.", nameof(tipo));
            }

            return receita;
        }
    }
}