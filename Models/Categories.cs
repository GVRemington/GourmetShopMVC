using System.ComponentModel.DataAnnotations;

namespace GourmetShopMVC.Models
{
    public class Categories
    {
        [Key]
        public int Id { get; set; }
        public required string CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
