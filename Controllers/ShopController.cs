using GourmetShopMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GourmetShopMVC.Controllers
{
    public class ShopController : Controller
    {
        private readonly GourmetShopMVC.Data.GourmetShopMVCContext _context;

        public ShopController(GourmetShopMVC.Data.GourmetShopMVCContext context)
        {
            _context = context;
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

            var model = new ShoppingViewModel
            {
                Products = products,
                Suppliers = suppliers,
                Categories = categories
                //User = user
            };

            return View(model);
        }
    }
}
