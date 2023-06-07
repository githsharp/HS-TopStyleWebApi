namespace HS_TopStyleWebApi.Repository.Repos
{
    internal class OrderItemRepository
    {
        // osäker på denna
        public int OrderId { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int OrderStatus { get; set; }
        public int Price { get; set; }
        public int TotalPrice { get; set; }

    }
}