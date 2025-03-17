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

        public async Task<ActionResult> Checkout()
        {

            var orderId = 0;

            // use the context to create a order, getting us an order id
            Order order = new Order
            {
                Id = 0,
                OrderDate = DateTime.Now,
                OrderNumber = null,
                UserId = 92,
                TotalAmount = null,
                OrderCancelled = false,
            };

            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            orderId = order.Id;

            decimal Subtotal = 0;

            // use the context to take our cartservice.cart and update all orderitems with the order id
            foreach( OrderItem item in _cartService.Cart)
            {
                item.OrderId = orderId;

                Subtotal += item.UnitPrice * item.Quantity;

                _context.OrderItem.Add(item);
            }

            order.TotalAmount = Subtotal;

            await _context.SaveChangesAsync();

            // use the context to create orderitem rows in the database (from the carservice.cart items)

            _cartService.EmptyCart();

            return RedirectToAction("Index", "Shop");
        }
    }
}
