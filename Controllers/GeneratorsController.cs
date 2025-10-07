using Microsoft.AspNetCore.Mvc;
using BackendGenerators.Data;
namespace BackendGenerators.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeneratorsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public GeneratorsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}