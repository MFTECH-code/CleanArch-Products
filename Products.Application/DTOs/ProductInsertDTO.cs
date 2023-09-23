using System.ComponentModel.DataAnnotations;

namespace Products.Application.DTOs
{
    public class ProductInsertDTO
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int Stock { get; set; } = 0;
    }
}