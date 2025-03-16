using GourmetShopMVC.Models;

namespace GourmetShopMVC.Services
{
    public class CartService
    {
        public List<OrderItem> Cart { get; set; }
        public List<Product> Products { get; set; }

        public CartService()
        {
            Cart = new List<OrderItem>();
            Products = new List<Product>();
        }

        public void AddItemToCart(Product item)
        {
            Products.Add(item);

            Cart.Add(new OrderItem
            {
                Id = 0,
                OrderId = 0,
                ProductId = item.Id,
                Quantity = 1,
                UnitPrice = (decimal)item.UnitPrice,
            });
        }

        public void EmptyCart()
        {
            Cart.Clear();
        }

        public void RemoveItem(Product item)
        {
            var orderItem = Cart.Find(x => x.ProductId == item.Id);

            if (orderItem != null)
            {
                Products.Remove(item);
                Cart.Remove(orderItem);
            }
        }

    }
    
}
