using HS_TopStyleWebApi.Repos.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HS_TopStyleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private readonly IProductRepo _repo;

        private readonly ProductContext _db;

        //Sätts upp via Dependency Injection för att kunna läsa från db

        public ProductController(ProductContext db)
        {
            _db = db;
        }   

        public IActionResult GetProducts()
        {
            var result = _db.Products.ToList();

            return Ok(result);
        }
    }
}
