using Microsoft.AspNetCore.Mvc;
using BackendGenerators.Data;
using BackendGenerators.Models;
using Microsoft.EntityFrameworkCore;
namespace BackendGenerators.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeneratorsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private static readonly Random _random = new Random();

        public GeneratorsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("pessoa")]
        public async Task<ActionResult<Pessoa>> GetPessoaAleatoria()
        {
            int total = await _appDbContext.Pessoas.CountAsync();
            if (total == 0) return NotFound("Nenhuma pessoa encontrada");

            int idAleatorio = _random.Next(1, total + 1);

            var pessoa = await _appDbContext.Pessoas
                .Skip(idAleatorio)
                .FirstOrDefaultAsync();

            return Ok(pessoa);
        }

        
    }
}