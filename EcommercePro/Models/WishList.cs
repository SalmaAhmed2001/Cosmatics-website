using System.ComponentModel.DataAnnotations.Schema;

namespace EcommercePro.Models
{
    public class WishList
    {
        public int Id { get; set; }
        public DateOnly? CreatedDate { get; set; }
        [ForeignKey("product")]
        public int productId { set; get; }

        public Product? product { set; get; }

        [ForeignKey("User")]
        public string UserId { set; get; }
        public ApplicationUser? User { get; set; }

    }
}
