namespace BeautyApp.Models
{
    public class Product
    {
        public int Id { get; set; }                 // Unique identifier for the product
        public required string Name { get; set; }   // Name of the product
        public string? Description { get; set; }    // Description of the product
        public decimal Price { get; set; }          // Price of the product
        public string? ImageUrl { get; set; }       // URL of the product image
    }
}
