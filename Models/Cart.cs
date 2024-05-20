namespace BeautyApp.Models
{
    public class Cart
    {
        public int Id { get; set; }                                         // Unique identifier for the cart
        public required String UserId { get; set; }                                     // ID of the user who owns the cart
        public required ICollection<CartItem> CartItems { get; set; }       // Collection of items in the cart
    }
}
