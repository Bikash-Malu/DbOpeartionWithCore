using DbOpeartionWithCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace DbOpeartionWithCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CurrencyController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCurrencies()
        {
            var currencies = await _appDbContext.Curancies.ToListAsync();
            if (currencies == null || !currencies.Any())
            {
                return NotFound("No currencies found.");
            }

            return Ok(currencies);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCurrencyById([FromRoute] int id)
        {
            var currency = await _appDbContext.Curancies.FindAsync(id);
            if (currency == null)
            {
                return NotFound($"Currency with ID {id} not found.");
            }

            return Ok(currency);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetCurrencyByName([FromRoute] string name)
        {
            var currency = await _appDbContext.Curancies
                .FirstOrDefaultAsync(x => x.Title.Equals(name));

            if (currency == null)
            {
                return NotFound($"Currency with name '{name}' not found.");
            }

            return Ok(currency);
        }
    }
}
