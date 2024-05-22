using EShopper.Data;
using EShopper.Infrastructure;
using EShopper.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace EShopper.Controllers
{
    public class CartController : Controller
    {
        public Cart? Cart { get; set; }
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            return View("Cart", Cart);
        }

        public IActionResult AddToCart(int productId)
        {
            Product? product = _context.Products.FirstOrDefault(p => p.PoductId == productId);

            if (product != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);
                HttpContext.Session.SetJson("cart", Cart);
            }
            return View("Cart", Cart);
        }

        public IActionResult DecreaseFromCart(int productId)
        {
            Product? product = _context.Products.FirstOrDefault(p => p.PoductId == productId);

            if (product != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, -1);
                HttpContext.Session.SetJson("cart", Cart);
            }
            return View("Cart", Cart);
        }

        public IActionResult RemoveFromCart(int productId)
        {
            Product? product = _context.Products.FirstOrDefault(p => p.PoductId == productId);

            if (product != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart");
                Cart.RemoveLine(product);
                HttpContext.Session.SetJson("cart", Cart);
            }
            return View("Cart", Cart);
        }
    }
}
