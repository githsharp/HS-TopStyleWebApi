using HS_TopStyleWebApi.Repos.Entities;
using HS_TopStyleWebApi.Repository.Interfaces;
using HS_TopStyleWebApi.Repository.Repos;
using HS_TopStyleWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HS_TopStyleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        //private readonly IOrderRepository _orderRepository;
        //private readonly IProductRepository _productRepository;
        //private readonly IUserRepository _userRepository;
        //private readonly IJwtTokenGenerator _jwtTokenGenerator;

        //public OrderController(IOrderRepository _orderRepository, IProductRepository productRepository, IJwtTokenGenerator jwtTokenGenerator, IUserRepository _userRepository)
        //{
        //    //_orderRepository = orderRepository; 
        //    _productRepository = productRepository;
        //    _jwtTokenGenerator = jwtTokenGenerator;
        //    //_userRepository = userRepository;
        //}

        private readonly ProductContext _db;
        //private readonly IOrderRepository orderRepository;
        //private readonly IUserRepository userRepository;

        public OrderController(ProductContext db)
        {
            _db = db;
        }


        //create an order
        [Authorize]
        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            _db.Orders.Add(order);
            _db.SaveChanges();
            return Ok(order);
        }
        
        //get all orders
        [Authorize]
        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = _db.Orders;
            return Ok(orders);
        }
    }
}
