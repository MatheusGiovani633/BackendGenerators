namespace BackendGenerators.Services
{
    using System.Collections.Generic;
    using BackendGenerators.Models;
    public interface IProcessService
    {
        Task<Receita> CriarReceitaAleatoriaAsync(int codPessoa, int codOrdemServicoCaixa, int codVendedor, int codMedico);
  
    }

}