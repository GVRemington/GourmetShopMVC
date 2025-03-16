using System.ComponentModel.DataAnnotations;

namespace GourmetShopMVC.Models
{
    public class ShopViewModel
    {
        public int Id { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Supplier> Suppliers { get; set; }
        public ICollection<Categories> Categories { get; set; }
        //public Users User { get; set; }
    }
}
