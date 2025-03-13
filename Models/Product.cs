using System.ComponentModel.DataAnnotations;

namespace GourmetShopMVC.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public required string ProductName { get; set; }
        public required int SupplierId { get; set; }
        public decimal? UnitPrice { get; set; }
        public string? Package { get; set; }
        public required bool IsDiscontinued  { get; set; }
        public int? CategoryId { get; set; }
    }
}
