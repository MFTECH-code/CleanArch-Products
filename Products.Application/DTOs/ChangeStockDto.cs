using System.ComponentModel.DataAnnotations;

namespace Products.Application.DTOs
{
    public class ChangeStockDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
