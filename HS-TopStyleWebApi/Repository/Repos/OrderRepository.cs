using HS_TopStyleWebApi.Repos.Entities;
using HS_TopStyleWebApi.Repository.Interfaces;
using HS_TopStyleWebApi.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using HS_TopStyleWebApi.DTOs.OrderDTOs;
using System.Linq;


namespace HS_TopStyleWebApi.Repository.Repos
{
    public class OrderRepository : IOrderRepository
    {
        // sätts upp via Dependency Injection för att kunna läsa från databasen
        private readonly ProductContext _db;
        public OrderRepository(ProductContext db)
        {
            _db = db;
        }

        // Create order
        // ska matcha mot denna:
        //       Task<Order> CreateOrder(CreateOrderDTO order);
        public async Task<Order> CreateOrder(CreateOrderDTO order)
        {
            var newOrder = new Order
            {
                UserId = order.UserId,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                TotalSum = order.TotalSum,
            };

            await _db.Orders.AddAsync(newOrder);
            await _db.SaveChangesAsync();
            var createdOrder = await _db.Orders.SingleOrDefaultAsync(o => o.OrderId == newOrder.OrderId);
            return createdOrder;
        }

    // Create order - variant
    // ska matcha mot denna:
    //       Task<Order> CreateOrder(CreateOrderDTO order);
    //public async Task<int> CreateOrder(CreateOrderDTO order)
    //{
    //    var newOrder = new Order
    //    {
    //        UserId = order.UserId,
    //        ProductId = order.ProductId,
    //        Quantity = order.Quantity,
    //        TotalSum = order.TotalSum,
    //    };

    //    await _db.Orders.AddAsync(newOrder);
    //    await _db.SaveChangesAsync();
    //    var createdOrder = await _db.Orders.SingleOrDefaultAsync(o => o.OrderId == newOrder.OrderId);
    //    return createdOrder.OrderId;
    //}

    // get all orders
    public async Task<List<OrderDTO>> GetOrder(OrderDTO order)
        {
            return await _db.Orders.Select(o => new OrderDTO
            {
                OrderId = o.OrderId,
                UserId = o.UserId,
                ProductId = o.ProductId,
                Quantity = o.Quantity,
                TotalSum = o.TotalSum,
            }).ToListAsync();
        }

        // Get order by id and return a list of orders
        public async Task <List<GetOrderDTO>> GetOrderById(int id)
        {
            var order = await _db.Orders.FirstOrDefaultAsync(o => o.OrderId == id);

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
    }
}

// Delete order by id
//public async Task <OrderDTO> DeleteOrder(int id)
//{
//    var order = await _db.Orders.FirstOrDefaultAsync(o => o.OrderId == id);

//    if (order == null)
//    //{
//    //    return null;
//    //}

//    _db.Orders.Remove(order);
//    await _db.SaveChangesAsync();
//    // return a value from the method of deleting an order matching the OrderDTO:

//    return order;
//return result is not null ? false : true;
