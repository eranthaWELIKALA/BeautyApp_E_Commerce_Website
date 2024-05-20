using BeautyApp.Models;

namespace BeautyApp.Services
{
    public interface ICartService
    {
        Task AddToCartAsync(String userId, int productId, int quantity);
        Task IncrementQuantityAsync(String userId, int productId, int quantity);
        Task DecrementQuantityAsync(String userId, int productId, int quantity);
        Task RemoveFromCartAsync(String userId, int productId);
        Task ClearCartAsync(String userId);
        Task<Cart> GetCartByUserIdAsync(String userId);
    }

}
