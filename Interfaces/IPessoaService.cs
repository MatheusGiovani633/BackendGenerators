namespace BackendGenerators.Services
{

    using BackendGenerators.Models;
    public interface IPessoaService
    {
        Task<Pessoa> CriarPessoaAleatoriaAsync(string tipo);
        Task<Medico> CriarMedicoAleatorioAsync(); 
        Task<Pessoa> GetPessoaAleatoriaAsync(string tipo);
        Task<Pessoa> GetPessoaByIdAsync(int id);

    }

}