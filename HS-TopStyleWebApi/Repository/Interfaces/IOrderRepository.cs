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
        Task<int> CreateOrder(CreateOrderDTO order);
        //alt denna:
        //Task<int> CreateOrder(CreateOrderDTO order);

        // GET - Get Order by Id
        //Task<OrderDTO?> GetOrderById(int id);
        //alt denna:
        //Task<List<SearchOrderDTO>> GetOrder();
        Task<List<GetOrderDTO>> GetOrderById(int id);

        // DELETE - Delete Order by Id
       // Task<OrderDTO> DeleteOrder(int id);
        //alt denna:
        //Task<Boolean> DeleteOrder(int orderId);
    }
}
