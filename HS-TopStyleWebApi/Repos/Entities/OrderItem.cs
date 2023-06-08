using System.ComponentModel.DataAnnotations;

namespace HS_TopStyleWebApi.Repos.Entities
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        
        public OrderItem( int orderItemId, int orderId, int userId, int productId, int quantity)
        {
            OrderItemId = orderItemId;
            OrderId = orderId;
            UserId = userId;
            ProductId = productId;
            Quantity = quantity;
        }

    }
}
