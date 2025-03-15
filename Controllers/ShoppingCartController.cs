using GourmetShopMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GourmetShopMVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly GourmetShopMVC.Data.GourmetShopMVCContext _context;

        public ShoppingCartController(GourmetShopMVC.Data.GourmetShopMVCContext context)
        {
            _context = context;
        }

        public List<Product> ShoppingCartItems { get; set; }

        public void AddtoCart(Product product, int itemQuantity, double price)
        {
            if(product == null)
            {
                ShoppingCartItems = new List<Product>()
                {
                    //TODO:
                };
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
