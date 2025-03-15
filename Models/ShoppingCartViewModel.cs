namespace GourmetShopMVC.Models
{
    public class ShoppingCartViewModel
    {
        public int shoppingCartId { get; set; }
        public int itemQuantity { get; set; }
        public double price { get; set; }
        public double totalPrice { get; set; }
        public Product product { get; set; }
    }
}

