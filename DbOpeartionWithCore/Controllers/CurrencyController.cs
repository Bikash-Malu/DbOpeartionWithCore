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

        // GET: api/currency
        [HttpGet]
        public async Task<IActionResult> GetAllCurrencies()
        {
            var currencies = await _appDbContext.Curancies.ToListAsync();
            if (!currencies.Any())
            {
                return NotFound("No currencies found.");
            }

            return Ok(currencies);
        }

        [HttpPost]
        public async Task<IActionResult> AddCurrency([FromBody] Currancy newCurrency)
        {
            if (newCurrency == null)
                return BadRequest("Currency data is null.");

            if (await _appDbContext.Curancies.AnyAsync(x => x.Title == newCurrency.Title))
                return Conflict($"A currency with the title '{newCurrency.Title}' already exists.");

            await _appDbContext.Curancies.AddAsync(newCurrency);
            await _appDbContext.SaveChangesAsync();

            return Ok(newCurrency);
        }


        // GET: api/currency/{id}
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

        // GET: api/currency/{name}
        [HttpGet("{name}")]
        public async Task<IActionResult> GetCurrencyByName([FromRoute] string name)
        {
            var currency = await _appDbContext.Curancies.FirstOrDefaultAsync(x => x.Title.Equals(name));
            if (currency == null)
            {
                return NotFound($"Currency with name '{name}' not found.");
            }

            return Ok(currency);
        }

        // GET: api/currency/{name}/{desc}
        [HttpGet("{name}/{desc}")]
        public async Task<IActionResult> GetNameWithDescription([FromRoute] string name, [FromRoute] string desc)
        {
            var currency = await _appDbContext.Curancies
                .FirstOrDefaultAsync(x => x.Title.Equals(name) && x.Description.Equals(desc));
            if (currency == null)
            {
                return NotFound("Currency with the specified name and description not found.");
            }

            return Ok(currency);
        }

        // DELETE: api/currency/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCurrency([FromRoute] int id)
        {
            var currency = await _appDbContext.Curancies.FindAsync(id);
            if (currency == null)
            {
                return NotFound($"Currency with ID {id} not found.");
            }

            _appDbContext.Curancies.Remove(currency);
            await _appDbContext.SaveChangesAsync();

            return Ok($"Currency with ID {id} has been deleted.");
        }

        // PUT: api/currency/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCurrency([FromRoute] int id, [FromBody] Currancy updatedCurrency)
        {
            if (id != updatedCurrency.Id)
            {
                return BadRequest("ID in the URL does not match the ID in the body.");
            }

            var currency = await _appDbContext.Curancies.FindAsync(id);
            if (currency == null)
            {
                return NotFound($"Currency with ID {id} not found.");
            }

            currency.Title = updatedCurrency.Title;
            currency.Description = updatedCurrency.Description;

            _appDbContext.Curancies.Update(currency);
            await _appDbContext.SaveChangesAsync();

            return Ok(currency);
        }
    }
}
