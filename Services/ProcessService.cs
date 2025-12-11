
namespace BackendGenerators.Services
{
    using BackendGenerators.Repository;
    using BackendGenerators.Helpers;
    using BackendGenerators.Models;
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
       

    }
}