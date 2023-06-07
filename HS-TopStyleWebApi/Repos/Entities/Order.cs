using System.ComponentModel.DataAnnotations;

namespace HS_TopStyleWebApi.Repos.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int TotalSum { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
        public virtual User? Users { get; set; }

        public Order()
        {
        }

        //public Order(int orderId, int userId, int productId, int quantity, int totalSum)
        //{
        //    OrderId = orderId;
        //    UserId = userId;
        //    ProductId = productId;
        //    Quantity = quantity;
        //    TotalSum = totalSum;
        //}
    }
}
