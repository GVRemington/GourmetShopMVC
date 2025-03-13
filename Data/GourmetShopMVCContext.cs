using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GourmetShopMVC.Models;

namespace GourmetShopMVC.Data
{
    public class GourmetShopMVCContext : DbContext
    {
        public GourmetShopMVCContext (DbContextOptions<GourmetShopMVCContext> options)
            : base(options)
        {
        }

        public DbSet<GourmetShopMVC.Models.Supplier> Supplier { get; set; } = default!;
        public DbSet<GourmetShopMVC.Models.Product> Product { get; set; } = default!;
        public DbSet<GourmetShopMVC.Models.Categories> Categories { get; set; } = default!;
        public DbSet<GourmetShopMVC.Models.Order> Order { get; set; } = default!;
        public DbSet<GourmetShopMVC.Models.OrderItem> OrderItem { get; set; } = default!;
        public DbSet<GourmetShopMVC.Models.Users> Users { get; set; } = default!;
    }
}
