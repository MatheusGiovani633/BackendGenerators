
using BackendGenerators.Models;
using BackendGenerators.Services;
using Microsoft.AspNetCore.Mvc;
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
        var pessoa = await _pessoaService.CriarPessoaAleatoriaAsync(tipo);
        if (tipo == "Fisica" || tipo == "fisica")
        {
            var pessoaFisicaDto = Pessoa.ToPessoaFisicaDto(pessoa);
            return Ok(pessoaFisicaDto);
        }
        else if (tipo == "Juridica" || tipo == "juridica")
        {
            var pessoaJuridicaDto = Pessoa.ToPessoaJuridicaDto(pessoa);
            return Ok(pessoaJuridicaDto);
        }
        else
        {
            return BadRequest("Tipo inválido. Use 'fisica' ou 'juridica'.");
        }
    }

    [HttpGet("pessoa/{tipo}")]
    public async Task<ActionResult<Pessoa>> GetPessoaTipoAleatoria(string tipo)
    {
        var pessoa = await _pessoaService.GetPessoaAleatoriaTipoAsync(tipo);
        if (tipo == "Fisica" || tipo == "fisica")
        {
            var pessoaFisicaDto = Pessoa.ToPessoaFisicaDto(pessoa);
            return Ok(pessoaFisicaDto);
        }
        else if (tipo == "Juridica" || tipo == "juridica")
        {
            var pessoaJuridicaDto = Pessoa.ToPessoaJuridicaDto(pessoa);
            return Ok(pessoaJuridicaDto);
        }
        else
        {
            return BadRequest("Tipo inválido. Use 'fisica' ou 'juridica'.");
        }
    }

    [HttpGet("pessoa")]
    public async Task<ActionResult<List<Pessoa>>> GetPessoaAleatoria()
    {
        var pessoas = await _pessoaService.GetPessoaAleatoriaAsync();
        if (pessoas == null)
            return StatusCode(500, "Erro ao buscar pessoas.");

        if (pessoas.Count == 0)
            return NoContent();

        var pessoasDto = pessoas.Select(p => Pessoa.ToPessoaDto(p)).ToList();
        return Ok(pessoasDto);
    }

    [HttpGet("pessoa/{id:int}")]
    public async Task<ActionResult<Pessoa>> GetPessoaId(int id)
    {
        var pessoa = await _pessoaService.GetPessoaByIdAsync(id);
        if (pessoa == null) return NotFound("O ID informado não existe");
        var pessoaDto = Pessoa.ToPessoaDto(pessoa);
        return Ok(pessoaDto);
    }

    [HttpPost("medico")]
    public async Task<ActionResult<Medico>> CriarMedicoAleatorio()
    {
        var medico = await _pessoaService.CriarMedicoAleatorioAsync();
        if (medico == null) return BadRequest("Erro ao criar médico.");
        var medicoDto = Pessoa.ToMedicoDto(medico.Pessoa);
        return Ok(medicoDto);
    }

    [HttpGet("medico")]
    public async Task<ActionResult<List<Medico>>> GetMedicoAleatorio()
    {

        var medicos = await _pessoaService.GetMedicoAleatorioAsync();
        if (medicos == null)
            return StatusCode(500, "Erro ao buscar medicos.");

        if (medicos.Count == 0)
            return NoContent();

        var medicosDto = medicos.Select(m => Pessoa.ToMedicoDto(m.Pessoa)).ToList();
        return Ok(medicosDto);
        
    }

}
