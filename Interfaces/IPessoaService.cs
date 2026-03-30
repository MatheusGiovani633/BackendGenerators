namespace BackendGenerators.Services
{
    using System.Collections.Generic;
    using BackendGenerators.Models;
    public interface IPessoaService
    {
        Task<Pessoa> CriarPessoaAleatoriaAsync(Tipo tipo);
        Task<Medico> CriarMedicoAleatorioAsync();
        Task<Pessoa> GetPessoaAleatoriaTipoAsync(Tipo tipo);
        Task<Pessoa> GetPessoaByIdAsync(int id);
        Task<List<Pessoa>> GetPessoaAleatoriaAsync(int page, int pageSize);
        Task<List<Medico>> GetMedicoAleatorioAsync();
    }

}