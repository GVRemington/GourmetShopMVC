using GourmetShopMVC.Data;
using GourmetShopMVC.Models;
using GourmetShopMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace GourmetShopMVC.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly CartService _cartService;
        private readonly GourmetShopMVCContext _context;

        public CheckoutController(GourmetShopMVCContext ctx, CartService cart)
        {
            _cartService = cart;
            _context = ctx;
        }

        public ActionResult Index()
        {
            CartViewModel model = new CartViewModel
            {
                Cart = _cartService.Cart,
                Products = _cartService.Products
            };

            return View(model);
        }

        public ActionResult ClearCart()
        {
            _cartService.EmptyCart();
            return RedirectToAction("Index");
        }

        public ActionResult Checkout()
        {

            // use the context to create a order, getting us an order id

            // use the context to take our cartservice.cart and update all orderitems with the order id

            // use the context to create orderitem rows in the database (from the carservice.cart items)

            return NotFound();
        }
    }
}
