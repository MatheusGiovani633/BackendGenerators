
using BackendGenerators.Models;
using BackendGenerators.Services;
using Microsoft.AspNetCore.Mvc;
public class ProcessGeneratorsController : ControllerBase
{
    private readonly IProcessService _processService;
    private readonly IPessoaService _pessoaService;

    public ProcessGeneratorsController(IProcessService processService, IPessoaService pessoaService)
    {
        _processService = processService;
        _pessoaService = pessoaService;
    }

    [HttpPost("receita")]
    public async Task<ActionResult<Receita>> CriarReceitaAleatoria()
    {
        var pessoa = await _pessoaService.GetPessoaAleatoriaAsync();
        var vendedor = await _pessoaService.GetPessoaAleatoriaAsync();
        var ordemServicoCaixa = 2; // Simulação de obtenção de uma OrdemServicoCaixa aleatória
        var medico = await _pessoaService.GetMedicoAleatorioAsync();

        var receita = await _processService.CriarReceitaAleatoriaAsync(
            pessoa.Select(p => p.Cod_Pessoa).FirstOrDefault(),
            ordemServicoCaixa,
            vendedor.Select(v => v.Cod_Pessoa).FirstOrDefault(),
            medico.Select(m => m.Cod_Medico).FirstOrDefault()
        );
        if (receita == null) return BadRequest("Erro ao criar receita.");
        return Ok(receita);
    }

}