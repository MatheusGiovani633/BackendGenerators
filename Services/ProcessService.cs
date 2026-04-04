
namespace BackendGenerators.Services
{
    using System.Linq;
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
        public async Task<List<Receita>> ProcurarReceitaAsync(Tipo tipo, string nome)
        {
            var receitas = await _repo.ProcurarReceitaAsync(tipo, nome);
            if (receitas == null || receitas.Count == 0)
            {
                var receitaCriada = await _repo.CriarReceitaAleatoriaAsync(new Receita());
                return new List<Receita> { receitaCriada };
            }
            if (receitas.Any(r => r.Pessoa == null))
            {
                throw new ArgumentException("Não há pessoas cadastrasdas para esse tipo de operação, utilizar o endpoint /pessoas");
            }
            if (!Enum.IsDefined(typeof(Tipo), tipo))
            {
                throw new ArgumentException("Tipo é obrigatório e deve ser válido.", nameof(tipo));
            }

            return receitas;
        }
    }
}