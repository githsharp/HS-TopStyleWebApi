using System.ComponentModel.DataAnnotations;

namespace HS_TopStyleWebApi.Repos.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string? CategoryName { get; set; }


        // varje kategori kan ha flera produkter
        public virtual ICollection<Product>? Products { get; set; }

        public Category(int categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

    }
}
