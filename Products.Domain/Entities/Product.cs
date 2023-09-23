using System.ComponentModel.DataAnnotations;

namespace Products.Domain.Entities
{
    public class Product
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime UpdatedDate { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string NormalizedName { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int Stock { get; set; } = 0;
    }
}
