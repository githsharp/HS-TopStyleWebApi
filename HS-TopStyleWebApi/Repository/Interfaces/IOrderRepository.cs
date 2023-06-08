using HS_TopStyleWebApi.DTOs.OrderDTOs;
using HS_TopStyleWebApi.DTOs.ProductDTOs;
using HS_TopStyleWebApi.DTOs.UserDTOs;
using HS_TopStyleWebApi.Repos.Entities;
using System.Threading.Tasks;
using System.Threading;

namespace HS_TopStyleWebApi.Repository.Interfaces
{
    public interface IOrderRepository
    {
        // POST - Create Order
        // pausar denna:
        //
        Task<Order> CreateOrder(CreateOrderDTO order);
        //provar istället denna:
        //
       // Task<int> CreateOrder(CreateOrderDTO order);

        // GET - Get Order by Id
        //Task<List<GetOrderDTO>> GetOrderById(int id);

        // GET - Get all orders
        Task<List<OrderDTO>> GetOrder(OrderDTO order);

        // DELETE - Delete Order by Id
        // Task<OrderDTO> DeleteOrder(int id);
        //alt denna:
        //Task<Boolean> DeleteOrder(int orderId);
    }
}
