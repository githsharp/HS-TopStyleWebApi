using HS_TopStyleWebApi.Repos.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HS_TopStyleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // så småningom ska private readonly IProductRepository _productRepository; användas (istället för _db?)
        // så småningom även IOrderRepository och kanske även IUserRepository, ICategoryRepository 
        private readonly ProductContext _db;

        //Sätts upp via Dependency Injection för att kunna läsa från databasen

        public ProductController(ProductContext db)
        {
            _db = db;
        }

        // denna ska egentligen bort!
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
            return Ok(product);
        }

        //[AllowAnonymous]
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _db.Products;
            return Ok(products);
        }

    }
}
