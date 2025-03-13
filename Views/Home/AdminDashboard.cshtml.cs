using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GourmetShopMVC.Data;
using GourmetShopMVC.Models;

namespace GourmetShopMVC.Views.Home
{
    public class AdminDashboardModel : PageModel
    {
        private readonly GourmetShopMVC.Data.GourmetShopMVCContext _context;

        public AdminDashboardModel(GourmetShopMVC.Data.GourmetShopMVCContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Product.ToListAsync();
        }
    }
}
