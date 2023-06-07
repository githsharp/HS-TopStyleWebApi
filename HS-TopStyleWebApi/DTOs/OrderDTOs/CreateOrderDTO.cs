using System.ComponentModel.DataAnnotations;
using HS_TopStyleWebApi.Repos.Entities;

namespace HS_TopStyleWebApi.DTOs.OrderDTOs
{
    public class CreateOrderDTO
    {
        // har plockat bort alla Required för att kunna söka på enbart en av dessa properties
        //public int OrderId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int TotalSum { get; set; }
    }
}
