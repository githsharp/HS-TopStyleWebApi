﻿using System.ComponentModel.DataAnnotations;

namespace HS_TopStyleWebApi.Repos.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string? CategoryName { get; set; }

        public virtual ICollection<Product>? Products { get; set; }

        public Category()
        {
        }

    }
}
