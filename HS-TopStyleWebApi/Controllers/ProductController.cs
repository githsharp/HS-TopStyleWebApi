using HS_TopStyleWebApi.Repos.Entities;
using HS_TopStyleWebApi.Repository.Interfaces;
using HS_TopStyleWebApi.Repository.Repos;
using HS_TopStyleWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HS_TopStyleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private readonly IProductRepository _productRepository;
        //private readonly IOrderRepository _orderRepository;
        //private readonly IUserRepository _userRepository;
        //private readonly IJwtTokenGenerator _jwtTokenGenerator;

        //public ProductController(IProductRepository productRepository, IJwtTokenGenerator jwtTokenGenerator) 
        //{
        //    _productRepository = productRepository;
        //    _jwtTokenGenerator = jwtTokenGenerator;
        //    /_userRepository = userRepository;
        //    _orderRepository = orderRepository;
        //}

        //Sätts upp via Dependency Injection för att kunna läsa från databasen

        private readonly ProductContext _db;
        public ProductController(ProductContext db)
        {
            _db = db;
        }

        // denna ska egentligen bort!
        //[Authorize]
        //[HttpPost]
        //public IActionResult CreateProduct(Product product)
        //{
        //    _db.Products.Add(product);
        //    _db.SaveChanges();
        //    return Ok(product);
        //}

        // get - all products
        //[AllowAnonymous]
        [HttpGet("allproducts")]
        public IActionResult GetProduct()
        {
            var result = _db.Products.ToList();
            return Ok(result);

        }
        // get - all products by category
        // [AllowAnonymous]
        //[HttpGet("{CategoryId}")]
        [HttpGet("productbycategory")]
        public IActionResult GetProductByCategory(int CategoryId)
        {
            var products = _db.Products.Where(p => p.CategoryId == CategoryId);
            return Ok(products);
        }

        // get product by price
        //[AllowAnonymous]
        [HttpGet("productbyprice")]
        public IActionResult GetProductByPrice(decimal Price)
        {
            var products = _db.Products.Where(p => p.Price == Price);
            return Ok(products);
        }

        //get product by name
        //[AllowAnonymous]
        [HttpGet("productbyname")]
        public IActionResult GetProductByName(string ProductName)
        {
            var products = _db.Products.Where(p => p.ProductName == ProductName);
            return Ok(products);
        }


    }
}
