namespace BackendGenerators.Services
{
    using System.Collections.Generic;
    using BackendGenerators.Models;
    public interface IPessoaService
    {
        Task<Pessoa> CriarPessoaAleatoriaAsync(string tipo);
        Task<Medico> CriarMedicoAleatorioAsync();
        Task<Pessoa> GetPessoaAleatoriaTipoAsync(string tipo);
        Task<Pessoa> GetPessoaByIdAsync(int id);
        Task<List<Pessoa>> GetPessoaAleatoriaAsync();
    }

}