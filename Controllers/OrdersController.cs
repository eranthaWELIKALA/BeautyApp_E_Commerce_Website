using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeautyApp.Models;
using Microsoft.AspNetCore.Identity;
using BeautyApp.Services;
using Microsoft.AspNetCore.Authorization;

namespace BeautyApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IOrderService _orderService;
        private readonly UserManager<User> _userManager;

        public OrdersController(ApplicationDbContext context, IOrderService orderService, UserManager<User> userManager)
        {
            _context = context;
            _orderService = orderService;
            _userManager = userManager;
        }
        private async Task<String> GetCurrentUserIdAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            return user.Id;
        }

        // GET: Orders
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Index()
        {
            var userId = await GetCurrentUserIdAsync();
            return View(await _orderService.GetOrdersByUserIdAsync(userId));
        }

        // GET: Orders/Details/5
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(c => c.OrderItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
