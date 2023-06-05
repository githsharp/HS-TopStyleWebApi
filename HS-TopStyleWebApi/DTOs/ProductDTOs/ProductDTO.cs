using System.ComponentModel.DataAnnotations;
using HS_TopStyleWebApi.Repos.Entities;

namespace HS_TopStyleWebApi.DTOs.ProductDTOs
{
    public class ProductDTO
    {
        // har plockat bort alla Required för att kunna söka på enbart en av dessa properties
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Price { get; set; } = 0;
        public string Category { get; set; } = null!;
        public object? CategoryName { get; internal set; }
        public int CategoryId { get; internal set; }
    }
}
