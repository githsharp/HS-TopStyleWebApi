using System.ComponentModel.DataAnnotations;

namespace HS_TopStyleWebApi.DTOs.ProductDTOs
{
    public class CreateProductDTO
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public int Price { get; set; } = 0;
        [Required]
        public string Category { get; set; } = null!;
        public object? CategoryName { get; internal set; }
    }
}
