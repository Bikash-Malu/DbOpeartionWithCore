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

        public CurrencyController( AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        [HttpGet]
        public IActionResult GetAllCurrency()
        {
            //var result=appDbContext.Curancies.ToList();
            var result = (from currencies in appDbContext.Curancies select currencies).ToList();
            return Ok(result);
        }
    }
}
