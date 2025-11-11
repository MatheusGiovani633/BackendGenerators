
using BackendGenerators.Models;
using BackendGenerators.Services;
using Microsoft.AspNetCore.Mvc;
using BackendGenerators.Models.Dtos;
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

        var pessoasDto = pessoas.Select(p => new PessoaDto
        {
            Cod_pessoa = p.Cod_Pessoa,
            Identificador = p.Identificador,
            Nome = p.Nome,
            Razaosocial = p.Razaosocial,
            Email = p.Email,
            Telefone = p.Telefone,
            Celular = p.Celular,
            Celular2 = p.Celular2,
            DataNascimento = p.DataNascimento,
            Cpf = p.Cpf,
            Cnpj = p.Cnpj,
            Sexo = p.Sexo,
            Cep = p.Cep,
            Logradouro = p.Logradouro,
            Numero = p.Numero,
            Cidade = p.Cidade,
            Estado = p.Estado,
            Complemento = p.Complemento,
            Bairro = p.Bairro,
            InscricaoEstadual = p.InscricaoEstadual,
            InscricaoMunicipal = p.InscricaoMunicipal,
            TipoCNPJ = p.TipoCNPJ
        }).ToList();
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

        var medicosDto = medicos.Select(m => new MedicoDto
        {
            CRM = m.CRM,
            Identificador = m.Pessoa.Identificador,
            Nome = m.Pessoa.Nome,
            Email = m.Pessoa.Email,
            Telefone = m.Pessoa.Telefone,
            Celular = m.Pessoa.Celular,
            Celular2 = m.Pessoa.Celular2,
            DataNascimento = m.Pessoa.DataNascimento,
            Cpf = m.Pessoa.Cpf,
            Sexo = m.Pessoa.Sexo,
            Cep = m.Pessoa.Cep,
            Logradouro = m.Pessoa.Logradouro,
            Numero = m.Pessoa.Numero,
            Cidade = m.Pessoa.Cidade,
            Estado = m.Pessoa.Estado,
            Complemento = m.Pessoa.Complemento,
            Bairro = m.Pessoa.Bairro,
        }).ToList();
        return Ok(medicosDto);
        
    }

}
