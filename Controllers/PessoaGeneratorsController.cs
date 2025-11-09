
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
            var pessoaFisicaDto = new PessoaFisicaDto
            {
                Identificador = pessoa.Identificador,
                Nome = pessoa.Nome,
                Email = pessoa.Email,
                Telefone = pessoa.Telefone,
                Celular = pessoa.Celular,
                Celular2 = pessoa.Celular2,
                DataNascimento = pessoa.DataNascimento,
                Cpf = pessoa.Cpf,
                Sexo = pessoa.Sexo,
                Cep = pessoa.Cep,
                Logradouro = pessoa.Logradouro,
                Numero = pessoa.Numero,
                Cidade = pessoa.Cidade,
                Estado = pessoa.Estado,
                Complemento = pessoa.Complemento,
                Bairro = pessoa.Bairro,
            };
            return Ok(pessoaFisicaDto);
        }
        else if (tipo == "Juridica" || tipo == "juridica")
        {
            var pessoaJuridicaDto = new PessoaJuridicaDto
            {
                Identificador = pessoa.Identificador,
                Nome = pessoa.Nome,
                Razaosocial = pessoa.Razaosocial,
                Email = pessoa.Email,
                Telefone = pessoa.Telefone,
                Celular = pessoa.Celular,
                Celular2 = pessoa.Celular2,
                DataNascimento = pessoa.DataNascimento,
                Cnpj = pessoa.Cnpj,
                Cep = pessoa.Cep,
                Logradouro = pessoa.Logradouro,
                Numero = pessoa.Numero,
                Cidade = pessoa.Cidade,
                Estado = pessoa.Estado,
                Complemento = pessoa.Complemento,
                Bairro = pessoa.Bairro,
                InscricaoEstadual = pessoa.InscricaoEstadual,
                InscricaoMunicipal = pessoa.InscricaoMunicipal,
                TipoCNPJ = pessoa.TipoCNPJ,
            };
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
            var pessoaFisicaDto = new PessoaFisicaDto
            {
                Identificador = pessoa.Identificador,
                Nome = pessoa.Nome,
                Email = pessoa.Email,
                Telefone = pessoa.Telefone,
                Celular = pessoa.Celular,
                Celular2 = pessoa.Celular2,
                DataNascimento = pessoa.DataNascimento,
                Cpf = pessoa.Cpf,
                Sexo = pessoa.Sexo,
                Cep = pessoa.Cep,
                Logradouro = pessoa.Logradouro,
                Numero = pessoa.Numero,
                Cidade = pessoa.Cidade,
                Estado = pessoa.Estado,
                Complemento = pessoa.Complemento,
                Bairro = pessoa.Bairro,
            };
            return Ok(pessoaFisicaDto);
        }
        else if (tipo == "Juridica" || tipo == "juridica")
        {
            var pessoaJuridicaDto = new PessoaJuridicaDto
            {
                Identificador = pessoa.Identificador,
                Nome = pessoa.Nome,
                Razaosocial = pessoa.Razaosocial,
                Email = pessoa.Email,
                Telefone = pessoa.Telefone,
                Celular = pessoa.Celular,
                Celular2 = pessoa.Celular2,
                DataNascimento = pessoa.DataNascimento,
                Cnpj = pessoa.Cnpj,
                Cep = pessoa.Cep,
                Logradouro = pessoa.Logradouro,
                Numero = pessoa.Numero,
                Cidade = pessoa.Cidade,
                Estado = pessoa.Estado,
                Complemento = pessoa.Complemento,
                Bairro = pessoa.Bairro,
                InscricaoEstadual = pessoa.InscricaoEstadual,
                InscricaoMunicipal = pessoa.InscricaoMunicipal,
                TipoCNPJ = pessoa.TipoCNPJ,
            };
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
            TipoCNPJ = p.TipoCNPJ,
        }).ToList();
        return Ok(pessoasDto);
    }

    [HttpGet("pessoaFisica/{id}")]
    public async Task<ActionResult<Pessoa>> GetPessoaId(int id)
    {
        var pessoa = await _pessoaService.GetPessoaByIdAsync(id);
        if (pessoa == null) return NotFound("O ID informado não existe");
        var pessoaDto = new PessoaDto
        {
            Cod_pessoa = pessoa.Cod_Pessoa,
            Identificador = pessoa.Identificador,
            Nome = pessoa.Nome,
            Razaosocial = pessoa.Razaosocial,
            Email = pessoa.Email,
            Telefone = pessoa.Telefone,
            Celular = pessoa.Celular,
            Celular2 = pessoa.Celular2,
            DataNascimento = pessoa.DataNascimento,
            Cpf = pessoa.Cpf,
            Cnpj = pessoa.Cnpj,
            Sexo = pessoa.Sexo,
            Cep = pessoa.Cep,
            Logradouro = pessoa.Logradouro,
            Numero = pessoa.Numero,
            Cidade = pessoa.Cidade,
            Estado = pessoa.Estado,
            Complemento = pessoa.Complemento,
            Bairro = pessoa.Bairro,
            InscricaoEstadual = pessoa.InscricaoEstadual,
            InscricaoMunicipal = pessoa.InscricaoMunicipal,
            TipoCNPJ = pessoa.TipoCNPJ,
        };
        return Ok(pessoaDto);
    }
    [HttpPost("medico")]
    public async Task<ActionResult<Medico>> CriarMedicoAleatorio()
    {
        var medico = await _pessoaService.CriarMedicoAleatorioAsync();
        if (medico == null) return BadRequest("Erro ao criar médico.");
        var medicoDto = new MedicoDto
        {
            CRM = medico.CRM,
            Identificador = medico.Pessoa.Identificador,
            Nome = medico.Pessoa.Nome,
            Email = medico.Pessoa.Email,
            Telefone = medico.Pessoa.Telefone,
            Celular = medico.Pessoa.Celular,
            Celular2 = medico.Pessoa.Celular2,
            DataNascimento = medico.Pessoa.DataNascimento,
            Cpf = medico.Pessoa.Cpf,
            Sexo = medico.Pessoa.Sexo,
            Cep = medico.Pessoa.Cep,
            Logradouro = medico.Pessoa.Logradouro,
            Numero = medico.Pessoa.Numero,
            Cidade = medico.Pessoa.Cidade,
            Estado = medico.Pessoa.Estado,
            Complemento = medico.Pessoa.Complemento,
            Bairro = medico.Pessoa.Bairro,
        };
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
