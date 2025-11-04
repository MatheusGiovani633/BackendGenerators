
using BackendGenerators.Models;
using BackendGenerators.Services;
using Microsoft.AspNetCore.Mvc;
using BackendGenerators.Models.Dtos;
using Mapster;
public class GeneratorsController : ControllerBase
{
    private readonly IPessoaService _pessoaService;

    public GeneratorsController(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService;
    }

    [HttpPost("pessoa/{tipo}")]
    public async Task<ActionResult<Pessoa>> CriarPessoaAleatoria(string tipo)
    {
        var created = await _pessoaService.CriarPessoaAleatoriaAsync(tipo);
        if (created == null) return BadRequest("Tipo inválido. Use 'fisica' ou 'juridica'.");
        return Ok(created);
    }

    [HttpGet("pessoa/{tipo}")]
    public async Task<ActionResult<Pessoa>> GetPessoaAleatoria(string tipo)
    {
        var pessoa = await _pessoaService.GetPessoaAleatoriaAsync(tipo);
        if (pessoa == null) return NotFound("Tipo inválido. Use 'fisica' ou 'juridica'.");
        var pessoaDto = pessoa.Adapt<PessoaDto>();

        return Ok(pessoaDto);
    }

    [HttpGet("pessoaFisica/{id}")]
    public async Task<ActionResult<Pessoa>> GetPessoaId(int id)
    {
        var pessoa = await _pessoaService.GetPessoaByIdAsync(id);
        if (pessoa == null) return NotFound("O ID informado não existe");
        var pessoaDto = pessoa.Adapt<PessoaDto>();

        return Ok(pessoaDto);
    }
    [HttpPost("medico")]
    public async Task<ActionResult<Medico>> CriarMedicoAleatorio()
    {
        var medico = await _pessoaService.CriarMedicoAleatorioAsync();
       if(medico == null) return BadRequest("Erro ao criar médico.");
       var medicoDto = medico.Adapt<MedicoDto>();
       return Ok(medicoDto);
    }

}
