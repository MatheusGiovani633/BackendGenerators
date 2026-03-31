
using BackendGenerators.Models;
using BackendGenerators.Services;
using Microsoft.AspNetCore.Mvc;
using BackendGenerators.Enums;
[ApiController]
[Route("api/[controller]")]
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
        var pessoa = await _pessoaService.GetPessoaAleatoriaAsync(page: 1, pageSize: 10);
        var vendedor = await _pessoaService.GetPessoaAleatoriaAsync(page: 1, pageSize: 10);
        var ordemServicoCaixa = Random.Shared.Next(1, 1000);
        var medico = await _pessoaService.GetMedicoAleatorioAsync();

        if (!pessoa.Any())
        {
            pessoa = new List<Pessoa> { await _pessoaService.CriarPessoaAleatoriaAsync(Tipo.Fisica) };
        }
        if (!vendedor.Any())
        {
            vendedor = new List<Pessoa> { await _pessoaService.CriarPessoaAleatoriaAsync(Tipo.Fisica) };
        }
        if (!medico.Any())
        {
            medico = new List<Medico> { await _pessoaService.CriarMedicoAleatorioAsync() };
        }

        var codPessoa = pessoa[Random.Shared.Next(pessoa.Count)].Cod_Pessoa;
        var codVendedor = vendedor[Random.Shared.Next(vendedor.Count)].Cod_Pessoa;
        var codMedico = medico[Random.Shared.Next(medico.Count)].Cod_Medico;

        var receita = await _processService.CriarReceitaAleatoriaAsync(
            codPessoa,
            ordemServicoCaixa,
            codVendedor,
            codMedico
        );
        if (receita == null) return BadRequest("Erro ao criar receita.");
        return Ok(receita);
    }
    [HttpGet("receita")]
    public async Task<ActionResult<Receita>> ProcurarReceita([FromQuery] string tipo, [FromQuery] string nome)
    {
        if (!Enum.TryParse<Tipo>(tipo, true, out var tipoEnum))
        {
            return BadRequest("Tipo inválido. Use 'fisica' ou 'juridica'.");
        }
        return tipoEnum switch
        {
            Tipo.Fisica => Ok(Receita.ToReceitaDto(await _processService.ProcurarReceitaAsync(Tipo.Fisica, nome))),
            Tipo.Juridica => Ok(Receita.ToReceitaDto(await _processService.ProcurarReceitaAsync(Tipo.Juridica, nome))),
            _ => BadRequest("Tipo inválido. Use 'fisica' ou 'juridica'.")

        };
    }



}