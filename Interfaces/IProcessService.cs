namespace BackendGenerators.Services
{
    using System.Collections.Generic;
    using BackendGenerators.Models;
    public interface IProcessService
    {
        Task<Receita> CriarReceitaAleatoriaAsync(int codPessoa, int codOrdemServicoCaixa, int codVendedor, int codMedico);
        Task CriarReceitaAleatoriaAsync(object cod_Pessoa1, int ordemServicoCaixa, object cod_Pessoa2, object cod_Medico);
    }

}