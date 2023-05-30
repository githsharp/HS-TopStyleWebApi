using HS_TopStyleWebApi.Repos.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HS_TopStyleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ProductContext _db;

        public OrderController(ProductContext db)
        {
            _db = db;
        }

        //[Authorize]
        //create an order
        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            _db.Orders.Add(order);
            _db.SaveChanges();
            return Ok(order);
        }
    }
}
