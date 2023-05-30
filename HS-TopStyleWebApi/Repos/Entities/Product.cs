using System.ComponentModel.DataAnnotations;

namespace HS_TopStyleWebApi.Repos.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(50)]
        public string? ProductName { get; set; }
        [Required]
        [StringLength(80)]
        public string? Description { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]

        // varje produkt tillhör en kategori
        public virtual Category? Categories { get; set; }
        // varje produkt kan finnas i flera ordrar
        public virtual ICollection <Order>? Orders { get; set; }    

        public Product()
        {
        }   
    }
}
