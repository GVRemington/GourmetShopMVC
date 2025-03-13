using System.ComponentModel.DataAnnotations;

namespace GourmetShopMVC.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public required int OrderId { get; set; }
        public required int ProductId { get; set; }
        public required decimal UnitPrice { get; set; }
        public required int Quantity { get; set; }
       
    }
}
