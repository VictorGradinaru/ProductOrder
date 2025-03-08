using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class OrderDto
    {
        public Guid Id { get; set; }

      
        public string ProductName { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        // Status devine opțional
        public string? Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
