using HS_TopStyleWebApi.DTOs.OrderDTOs;
using HS_TopStyleWebApi.DTOs.UserDTOs;
using HS_TopStyleWebApi.Repos.Entities;
using HS_TopStyleWebApi.Repository.Interfaces;
using HS_TopStyleWebApi.Repository.Repos;
using HS_TopStyleWebApi.Services.Authentication;
using HS_TopStyleWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace HS_TopStyleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ProductContext _db;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public OrderController(ProductContext db, IOrderRepository orderRepository, IProductRepository productRepository, IUserRepository userRepository)
        {
            _db = db;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        //create an order
        [Authorize]
        [HttpPost]
        public async Task <IActionResult> CreateOrder(CreateOrderDTO order)
        {
            var orderInDb = _db.Orders.FirstOrDefault(u => u.UserId == order.UserId);
            var createdOrder = await _orderRepository.CreateOrder(order);
            return Ok(createdOrder);

            //_db.Orders.Add(order);
            //var result = await _db.SaveChangesAsync();
            //return Ok(order);
        }


        //get all orders
        [Authorize]
        [HttpGet]
        public IActionResult GetOrders()
        {
            var result = _db.Orders.ToList();
            return Ok(result);
        }
    }
}
