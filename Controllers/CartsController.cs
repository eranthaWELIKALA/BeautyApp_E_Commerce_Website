using Microsoft.AspNetCore.Mvc;
using BeautyApp.Models;
using BeautyApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace BeautyApp.Controllers
{
    public class CartsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly UserManager<User> _userManager;

        public CartsController(ApplicationDbContext context, ICartService cartService, IOrderService orderService, UserManager<User> userManager)
        {
            _context = context;
            _cartService = cartService;
            _orderService = orderService;
            _userManager = userManager;
        }

        private async Task<String> GetCurrentUserIdAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            return user.Id;
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            var userId = await GetCurrentUserIdAsync();
            await _cartService.AddToCartAsync(userId, productId, quantity);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> IncrementQuantity(int productId)
        {
            var userId = await GetCurrentUserIdAsync();
            await _cartService.IncrementQuantityAsync(userId, productId, 1);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> DecrementQuantity(int productId)
        {
            var userId = await GetCurrentUserIdAsync();
            await _cartService.DecrementQuantityAsync(userId, productId, 1);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            var userId = await GetCurrentUserIdAsync();
            await _cartService.RemoveFromCartAsync(userId, productId);
            return RedirectToAction(nameof(Index));
        }

        // GET: Carts
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Index()
        {
            var userId = await GetCurrentUserIdAsync();
            return View(await _cartService.GetCartByUserIdAsync(userId));
        }

        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.Id == id);
        }

        // GET: Carts/ConfirmOrder
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> ConfirmOrder()
        {
            var userId = await GetCurrentUserIdAsync();
            var cart = await _cartService.GetCartByUserIdAsync(userId);

            if (cart == null || !cart.CartItems.Any())
            {
                return RedirectToAction("Index", "Products");
            }

            var viewModel = new ConfirmOrderViewModel();
            return View(viewModel);
        }

        // POST: Carts/ConfirmOrder
        [Authorize(Roles = "Customer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmOrder(ConfirmOrderViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var userId = await GetCurrentUserIdAsync();
            var cart = await _cartService.GetCartByUserIdAsync(userId);

            if (cart == null || !cart.CartItems.Any())
            {
                return RedirectToAction("Index", "Products");
            }

            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                ReceiverName = viewModel.ReceiverName,
                ContactNumber = viewModel.ContactNumber,
                Address = viewModel.Address,
                OrderItems = cart.CartItems.Select(ci => new OrderItem
                {
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity
                }).ToList()
            };

            await _orderService.CreateOrderAsync(order);
            await _cartService.ClearCartAsync(userId);

            return RedirectToAction("Index", "Orders");
        }
    }
}
