
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
    public async Task<ActionResult<Pessoa>> GetPessoaTipoAleatoria(string tipo)
    {
        var pessoa = await _pessoaService.GetPessoaAleatoriaTipoAsync(tipo);
        if (tipo == "Fisica" || tipo == "fisica")
        {
            var pessoaFisicaDto = pessoa.Adapt<PessoaFisicaDto>();

            return Ok(pessoaFisicaDto);
        }
        else if (tipo == "Juridica" || tipo == "juridica")
        {
            var pessoaJuridicaDto = pessoa.Adapt<PessoaJuridicaDto>();

            return Ok(pessoaJuridicaDto);
        }
        else
        {
            return BadRequest("Tipo inválido. Use 'fisica' ou 'juridica'.");
        }
    }

    [HttpGet("pessoa")]
    public async Task<ActionResult<List<Pessoa>>> GetPessoaAleatoria(string tipo)
    {
        var pessoas = await _pessoaService.GetPessoaAleatoriaAsync();
        if (pessoas == null)
            return StatusCode(500, "Erro ao buscar pessoas.");

        if (pessoas.Count == 0)
            return NoContent();

        var pessoasDto = pessoas.Adapt<List<PessoaDto>>();
        return Ok(pessoasDto);
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
