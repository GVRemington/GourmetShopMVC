using System.ComponentModel.DataAnnotations;

namespace GourmetShopMVC.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public bool? IsInactive { get; set; }

    }
}
