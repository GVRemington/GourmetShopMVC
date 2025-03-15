using System.ComponentModel.DataAnnotations;

namespace GourmetShopMVC.Models
{
    public class Categories
    {
        [Key]
        public int category_id { get; set; }
        public required string category_name { get; set; }
        public int? parent_category_id { get; set; }
    }
}
