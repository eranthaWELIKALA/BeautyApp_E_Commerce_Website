using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyApp.Models
{
    public class CartItem
    {
        public int Id { get; set; }          // Unique identifier for the cart item
        public int CartId { get; set; }      // ID of the cart
        public int ProductId { get; set; }   // ID of the product
        public int Quantity { get; set; }    // Quantity of the product in the cart

        [ForeignKey("ProductId")]            // Foreign key property
        public Product Product { get; set; } // Navigation property
    }
}
