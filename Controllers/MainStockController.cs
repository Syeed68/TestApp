using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestProjectApi.Models;

namespace TestProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainStockController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MainStockController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<MainStock>>> GetAll()
        {
            var MainStock = await _context.MainStock.ToListAsync();
            return Ok(MainStock);
        }

        [HttpPost("SaveMainStock")]
        public  ActionResult SaveMainStock(MainStock mainStock)
        {
            var ExtStock = _context.MainStock.Where(x => x.Name == mainStock.Name).FirstOrDefault();
            try
            {
                if (ExtStock!=null)
                {
                    ExtStock.Qty=ExtStock.Qty+mainStock.Qty;
                    ExtStock.Price = ExtStock.Price;
                    _context.MainStock.Update(ExtStock);
                    _context.SaveChanges();
                    return Ok("Success");
                }
                else
                {
                    _context.MainStock.Add(mainStock);
                    _context.SaveChanges();
                    return Ok("Success");
                }
            }
            catch (Exception)
            {
                return Ok("Failed");
            }
        }
    }
}
