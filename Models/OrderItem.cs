using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyApp.Models
{
    public class OrderItem
    {
        public int Id { get; set; }                 // Unique identifier for the order item
        public int ProductId { get; set; }          // ID of the product
        public int Quantity { get; set; }           // Quantity of the product ordered
        public decimal Price { get; set; }          // Price of the product at the time of ordering
        
        [ForeignKey("ProductId")]
        public Product Product { get; set; }   // Navigation property for the order
    }
}
