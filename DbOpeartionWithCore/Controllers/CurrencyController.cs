using DbOpeartionWithCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOpeartionWithCore.Controllers
{
    [Route("api/currency")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public CurrencyController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        [HttpGet]
        //public IActionResult GetAllCurrency()
        //{ 
        //    //var result=appDbContext.Curancies.ToList();
        //    var result = (from currencies in appDbContext.Curancies select currencies).ToList();
        //    return Ok(result);
        //}
        public async Task<IActionResult> getAllCurrency()
        {
            var result = await appDbContext.Curancies.ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurrencyById([FromRoute] int id)
        {
            var result= await appDbContext.Curancies.FindAsync(id);
            //var result = (from currencies in appDbContext.Curancies select currencies).ToList();
            return Ok(result);
        }
    }
}
