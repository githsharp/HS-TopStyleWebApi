﻿using System.ComponentModel.DataAnnotations;

namespace HS_TopStyleWebApi.DTOs.OrderDTOs
{
    public class CreateOrderDTO
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }

        [Required]
        public int TotalSum { get; set; }
    }
}
