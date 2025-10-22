
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
            var created = await _pessoaService.CriarPessoaAleatoriaAsync(tipo);
            if (created == null) return BadRequest("Tipo inválido. Use 'fisica' ou 'juridica'.");
            return Ok(created);
        }

        [HttpGet("pessoa/{tipo}")]
        public async Task<ActionResult<Pessoa>> GetPessoaAleatoria(string tipo)
        {
            var pessoa = await _pessoaService.GetPessoaAleatoriaAsync(tipo);
            if (pessoa == null) return NotFound("Tipo inválido. Use 'fisica' ou 'juridica'.");
            return Ok(pessoa);
        }

        [HttpGet("pessoaFisica/{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoaId(int id)
        {
            var pessoa = await _pessoaService.GetPessoaByIdAsync(id);
            if (pessoa == null) return NotFound("O ID informado não existe");
            return Ok(pessoa);
        }
    }
