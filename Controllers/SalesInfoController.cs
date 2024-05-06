using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using TestProjectApi.Models;

namespace TestProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesInfoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public SalesInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<SalesInfo>>> GetAll()
        {
            var SaleInfo = await _context.SalesInfo.ToListAsync();
            return Ok(SaleInfo);
        }

        [HttpPost("SaveSalesInfo")]
        public ActionResult SaveSales(SalesInfo salesInfo)
        {
            var MainStock = _context.MainStock.Where(x => x.Name == salesInfo.ProductName).FirstOrDefault();
            if (MainStock == null) return Ok("Failed");
            using (var transaction = new TransactionScope())
            {
                try
                {
                    SalesInfo salesInf=new SalesInfo();
                    salesInf.ProductName = salesInfo.ProductName;
                    salesInf.UnitPrice = salesInfo.UnitPrice;
                    salesInf.Quantity = salesInfo.Quantity;
                    _context.SalesInfo.Add(salesInf);

                    MainStock.Qty = MainStock.Qty - salesInfo.Quantity;
                    _context.MainStock.Update(MainStock);
                    _context.SaveChanges();
                    transaction.Complete();
                    return Ok("Success");
                }
                catch (Exception)
                {
                    transaction.Dispose();
                    return Ok("Failed");
                }

            }
        }
    }
}
