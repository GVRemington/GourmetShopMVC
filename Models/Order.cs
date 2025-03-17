using System.ComponentModel.DataAnnotations;

namespace GourmetShopMVC.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public required DateTime OrderDate { get; set; }
        public string? OrderNumber { get; set; }
        public required int UserId { get; set; }
        public decimal? TotalAmount { get; set; }
        public bool? OrderCanceled { get; set; } = false;   
    }
}
