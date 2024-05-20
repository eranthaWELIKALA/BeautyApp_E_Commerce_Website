namespace BeautyApp.Models
{
    public class Order
    {
        public int Id { get; set; }                                     // Unique identifier for the order
        public String UserId { get; set; }                                 // ID of the user who placed the order
        public DateTime OrderDate { get; set; }                         // Date and time when the order was placed
        public required string ReceiverName { get; set; }                        // Name of the Order Receiver
        public required string ContactNumber { get; set; }                       // Contact no. of the Order Receiver
        public required string Address { get; set; }                             // Address of the Order Receiver
        public required ICollection<OrderItem> OrderItems { get; set; } // Collection of items included in the order
    }
}
