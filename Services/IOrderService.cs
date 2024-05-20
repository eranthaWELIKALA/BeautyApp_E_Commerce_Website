using BeautyApp.Models;

namespace BeautyApp.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(Order order);
        Task<List<Order>> GetOrdersByUserIdAsync(String userId);
    }
}
