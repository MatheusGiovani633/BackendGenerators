
using BackendGenerators.Models;
using BackendGenerators.Services;
using Microsoft.AspNetCore.Mvc;
using BackendGenerators.Enums;
using Microsoft.AspNetCore.OutputCaching;
using BackendGenerators.Helpers;

[ApiController]
[Route("api/[controller]")]
public class GeneratorsController : ControllerBase
{
    private readonly IPessoaService _pessoaService;
    private readonly IProcessService _processService;

    public GeneratorsController(IPessoaService pessoaService, IProcessService processService)
    {
        _pessoaService = pessoaService;
        _processService = processService;
    }

    [HttpPost("pessoa/{tipo}")]
    public async Task<ActionResult<Pessoa>> CriarPessoaAleatoria(string tipo)
    {
        if (!Enum.TryParse<Tipo>(tipo, true, out var tipoEnum))
        {
            return BadRequest("Tipo inválido. Use 'fisica' ou 'juridica'.");

        }
        var pessoa = await _pessoaService.CriarPessoaAleatoriaAsync(tipoEnum);
        return tipoEnum switch
        {
            Tipo.Fisica => Ok(new
            {
                Pessoa = Pessoa.ToPessoaFisicaDto(pessoa),
                Links = Helpers.CriarLinks(Url, "GetPessoaId", "CriarPessoa", pessoa.Identificador)
            }),
            Tipo.Juridica => Ok(new
            {
                Pessoa = Pessoa.ToPessoaJuridicaDto(pessoa),
                Links = Helpers.CriarLinks(Url, "GetPessoaId", "CriarPessoa", pessoa.Identificador)
            }),
            _ => BadRequest("Tipo inválido. Use 'fisica' ou 'juridica'.")
        };
    }

    [HttpGet("pessoa/{tipo}")]
    [OutputCache(Duration = 15)]
    public async Task<ActionResult<Pessoa>> GetPessoaTipoAleatoria(string tipo)
    {

        if (!Enum.TryParse<Tipo>(tipo, true, out var tipoEnum))
        {
            return BadRequest("Tipo inválido. Use 'fisica' ou 'juridica'.");

        }
        var pessoa = await _pessoaService.GetPessoaAleatoriaTipoAsync(tipoEnum);
        return tipoEnum switch
        {
            Tipo.Fisica => Ok(new
            {
                Pessoa = Pessoa.ToPessoaFisicaDto(pessoa),
                Links = Helpers.CriarLinks(Url, "GetPessoaId", "CriarPessoa", pessoa.Identificador)
            }),
            Tipo.Juridica => Ok(new
            {
                Pessoa = Pessoa.ToPessoaJuridicaDto(pessoa),
                Links = Helpers.CriarLinks(Url, "GetPessoaId", "CriarPessoa", pessoa.Identificador)
            }),
            _ => BadRequest("Tipo inválido. Use 'fisica' ou 'juridica'.")
        };
    }

    [HttpGet("pessoa")]
    [OutputCache(Duration = 15)]
    public async Task<ActionResult<List<Pessoa>>> GetPessoaAleatoria([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var pessoas = await _pessoaService.GetPessoaAleatoriaAsync(page, pageSize);

        if (pessoas == null)
            return StatusCode(500, "Erro ao buscar pessoas.");

        if (pessoas.Count == 0)
            return NoContent();

        var pessoasDto = pessoas.Select(p => Pessoa.ToPessoaDto(p)).ToList();
        return Ok(new
        {
            Pessoas = pessoasDto,
            Links = Helpers.CriarLinks(Url, "GetPessoaAleatoria", "CriarPessoa", null)
        });
    }

    [HttpGet("pessoa/{id:int}")]
    public async Task<ActionResult<Pessoa>> GetPessoaId(int id)
    {
        var pessoa = await _pessoaService.GetPessoaByIdAsync(id);
        if (pessoa == null) return NotFound("O ID informado não existe");
        var pessoaDto = Pessoa.ToPessoaDto(pessoa);
        return Ok(new
        {
            Pessoa = pessoaDto,
            Links = Helpers.CriarLinks(Url, "GetPessoaId", "CriarPessoa", pessoa.Identificador)
        });
    }

    [HttpPost("medico")]
    public async Task<ActionResult<Medico>> CriarMedicoAleatorio()
    {
        var medico = await _pessoaService.CriarMedicoAleatorioAsync();
        if (medico == null) return BadRequest("Erro ao criar médico.");
        var medicoDto = Pessoa.ToMedicoDto(medico.Pessoa);
        return Ok(new
        {
            Medico = medicoDto,
            Links = Helpers.CriarLinks(Url, "GetMedicobyId", "CriarMedico", medico.Pessoa.Identificador)
        });
    }

    [HttpGet("medico/{id:int}")]
    [OutputCache(Duration = 25)]
    public async Task<ActionResult<List<Medico>>> GetMedicobyId(int id)
    {

        var medicos = await _pessoaService.GetMedicoByIdAsync(id);
        if (medicos == null)
            return StatusCode(500, "Erro ao buscar médicos.");
        if (medicos.Count == 0)
            return NoContent();

        var medicosDto = medicos.Select(m => Pessoa.ToMedicoDto(m.Pessoa)).ToList();
        return Ok(new
        {
            Medicos = medicosDto,
            Links = Helpers.CriarLinks(Url, "GetMedicobyId", "CriarMedico", id)
        });
    }

}