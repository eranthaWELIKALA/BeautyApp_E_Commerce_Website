using BeautyApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BeautyApp.Services
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _context;

        public CartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddToCartAsync(String userId, int productId, int quantity)
        {
            var cart = await _context.Cart.Include(c => c.CartItems)
                                           .FirstOrDefaultAsync(c => c.UserId.Equals(userId));

            if (cart == null)
            {
                cart = new Cart { UserId = userId, CartItems = new List<CartItem>() };
                _context.Cart.Add(cart);
            }

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (cartItem == null)
            {
                cartItem = new CartItem { ProductId = productId, Quantity = quantity };
                cart.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += quantity;
            }

            await _context.SaveChangesAsync();
        }

        public async Task IncrementQuantityAsync(String userId, int productId, int quantity)
        {

            var cart = await _context.Cart.Include(c => c.CartItems)
                                           .FirstOrDefaultAsync(c => c.UserId.Equals(userId));

            if (cart == null)
            {
                cart = new Cart { UserId = userId, CartItems = new List<CartItem>() };
                _context.Cart.Add(cart);
            }

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (cartItem == null)
            {
                cartItem = new CartItem { ProductId = productId, Quantity = quantity };
                cart.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += quantity;
            }

            await _context.SaveChangesAsync();
        }

        public async Task DecrementQuantityAsync(String userId, int productId, int quantity)
        {

            var cart = await _context.Cart.Include(c => c.CartItems)
                                           .FirstOrDefaultAsync(c => c.UserId.Equals(userId));

            if (cart == null)
            {
                cart = new Cart { UserId = userId, CartItems = new List<CartItem>() };
                _context.Cart.Add(cart);
            }

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (cartItem == null)
            {
                cartItem = new CartItem { ProductId = productId, Quantity = quantity };
                cart.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity -= quantity;
                if (cartItem.Quantity <= 1)
                {
                    cartItem.Quantity = 1;
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task RemoveFromCartAsync(String userId, int productId)
        {
            var cart = await _context.Cart.Include(c => c.CartItems)
                                           .FirstOrDefaultAsync(c => c.UserId.Equals(userId));

            if (cart != null)
            {
                var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
                if (cartItem != null)
                {
                    cart.CartItems.Remove(cartItem);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task ClearCartAsync(String userId)
        {
            var cart = await _context.Cart.Include(c => c.CartItems)
                                           .FirstOrDefaultAsync(c => c.UserId.Equals(userId));

            if (cart != null)
            {
                cart.CartItems = [];
                await _context.SaveChangesAsync();

            }
        }

        public async Task<Cart> GetCartByUserIdAsync(String userId)
        {
            var cart = await _context.Cart
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .SingleOrDefaultAsync(c => c.UserId.Equals(userId));
            return cart;
        }
    }
}
