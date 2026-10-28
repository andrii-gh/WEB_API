using _01.Data;
using _01.Extensions;
using _01.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private const string CartSessionKey = "Cart";

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
            return View(cart);
        }

        public IActionResult AddToCart(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            var cart = HttpContext.Session.Get<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
            var cartItem = cart.FirstOrDefault(c => c.ProductId == id);

            if (cartItem == null)
            {
                if (product.Amount > 0)
                {
                    cart.Add(new CartItem
                    {
                        ProductId = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Quantity = 1,
                        MaxAmount = product.Amount
                    });
                }
            }
            else
            {
                if (cartItem.Quantity < cartItem.MaxAmount)
                {
                    cartItem.Quantity++;
                }
            }

            HttpContext.Session.Set(CartSessionKey, cart);
            return RedirectToAction("Index");
        }

        public IActionResult Increase(int id)
        {
            var cart = HttpContext.Session.Get<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
            var item = cart.FirstOrDefault(c => c.ProductId == id);

            if (item != null && item.Quantity < item.MaxAmount)
            {
                item.Quantity++;
                HttpContext.Session.Set(CartSessionKey, cart);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Decrease(int id)
        {
            var cart = HttpContext.Session.Get<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
            var item = cart.FirstOrDefault(c => c.ProductId == id);

            if (item != null)
            {
                item.Quantity--;
                if (item.Quantity <= 0)
                {
                    cart.Remove(item);
                }
                HttpContext.Session.Set(CartSessionKey, cart);
            }

            return RedirectToAction("Index");
        }
    }
}