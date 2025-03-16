using GourmetShopMVC.Data;
using GourmetShopMVC.Models;
using GourmetShopMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GourmetShopMVC.Controllers
{
    public class ShopController : Controller
    {
        private readonly GourmetShopMVCContext _context;
        private readonly CartService _cartService;

        public ShopController(GourmetShopMVCContext context, CartService cart)
        {
            _context = context;
            _cartService = cart;
        }

        public async Task<IActionResult> Index(int[] supplierid, int[] categoryid)
        {
            if (supplierid.Length == 0)
            {
                supplierid = _context.Supplier.Select(s => s.Id).ToList().ToArray<int>();
            }

            if (categoryid.Length == 0)
            {
                categoryid = _context.Categories.Select(c => c.category_id).ToList().ToArray();
            }

            ViewData["supplierid"] = supplierid;
            ViewData["categoryId"] = categoryid;
            ViewData["CurrentItemsInCart"] = _cartService.Cart.Count;

            var product = await _context.Product.Where(p => supplierid.Any(x => x == p.SupplierId)).ToListAsync();
            var supplier = _context.Supplier.ToList();

            var products = await _context.Product
                .Include(p => p.Supplier)
                .Include(p => p.Category)
                .Where(p => p.IsDiscontinued != true)
                .Where(p => supplierid.Any(x => x == p.SupplierId) && categoryid.Any(x => x == p.category_Id))
                .ToListAsync();
            var suppliers = await _context.Supplier
                .Where(s => s.IsInactive != true)
                .ToListAsync();
            var categories = await _context.Categories
                .ToListAsync();
            //var user = await _context.Users.Where(u => u.UserId == 0).FirstOrDefaultAsync();

            var model = new ShopViewModel
            {
                Products = products,
                Suppliers = suppliers,
                Categories = categories
                //User = user
            };

            return View(model);
        }

        public async Task<IActionResult> AddToCart(int productId, int[] supplierid, int[] categoryid)
        {
            var product = await _context.Product.FindAsync(productId);

            if (product == null)
            {
                return NotFound();
            }

            _cartService.AddItemToCart(product);

            return RedirectToAction("Index", "Shop", new { supplierid = supplierid, categoryid = categoryid });
        }
    }
}
