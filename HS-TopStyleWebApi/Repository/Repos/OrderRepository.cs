using HS_TopStyleWebApi.Repos.Entities;
using HS_TopStyleWebApi.Repository.Interfaces;
using HS_TopStyleWebApi.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using HS_TopStyleWebApi.Extensions;
using HS_TopStyleWebApi.DTOs.OrderDTOs;
using System.Linq;


namespace HS_TopStyleWebApi.Repository.Repos
{
    public class OrderRepository : IOrderRepository
    {

        private readonly string _connectionString;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IConfiguration _configuration;
        private readonly ProductContext _context;

        // är ovan samma som nedan?
        public OrderRepository(IConfiguration configuration, ProductContext context)
        {
            _configuration = configuration;
            _context = context;
            // ska _db = db; vara med?
            //
            // ***********
            //
        }

        // Create order
        public async Task<int> CreateOrder(CreateOrderDTO order)
        {
            var newOrder = new Order
            {
                OrderId = order.OrderId,
                UserId = order.UserId,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                TotalSum = order.TotalSum,
            };

            //await DbContext.Order.AddAsync(newOrder);
            await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();
            return newOrder;
        }

        // Get order by id and return a list of orders
        public async Task <List<GetOrderDTO>> GetOrderById(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == id);

            if (order == null)
            {
                return null;
            }

            return new List<GetOrderDTO>
            {
                new GetOrderDTO
                {
                    OrderId = order.OrderId,
                    UserId = order.UserId,
                    ProductId = order.ProductId,
                    Quantity = order.Quantity,
                    TotalSum = order.TotalSum,
                }
            };
        }

        // Delete order by id
        public async Task <OrderDTO?> DeleteOrder(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == id);

            if (order == null)
            {
                return null;
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return order;
        }
    }
}
