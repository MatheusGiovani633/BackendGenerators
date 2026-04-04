namespace BackendGenerators.Services
{
    using BackendGenerators.Enums;
    using BackendGenerators.Models;
    public interface IProcessService
    {
        Task<Receita> CriarReceitaAleatoriaAsync(int codPessoa, int codOrdemServicoCaixa, int codVendedor, int codMedico);
        Task<List<Receita>> ProcurarReceitaAsync(Tipo tipo, string nome);
    }

}