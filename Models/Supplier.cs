using System.ComponentModel.DataAnnotations;

namespace GourmetShopMVC.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        public required string MyProperty { get; set; }
        public string? ContactName { get; set; }
        public string? ContactTitle { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public bool? IsInactive { get; set; }
    }
}
