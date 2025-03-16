namespace GourmetShopMVC.Models
{
    public class CartViewModel
    {
        public List<OrderItem> Cart { get; set; }
        public List<Product> Products { get; set; }
    }
}
