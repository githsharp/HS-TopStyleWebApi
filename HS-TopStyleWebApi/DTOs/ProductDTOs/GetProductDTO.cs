namespace HS_TopStyleWebApi.DTOs.ProductDTOs
{
    public class GetProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; internal set; }
    }
}
