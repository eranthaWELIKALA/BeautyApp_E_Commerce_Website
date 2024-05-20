using System.Threading.Tasks;
using BeautyApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BeautyApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(String userId)
        {
            var orders = await _context.Orders
                .Where(c => c.UserId.Equals(userId)).ToListAsync();
            return orders;
        }
    }
}
