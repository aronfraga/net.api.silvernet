using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silvernet.Models {
	public class OrderDetails {

		[Key]
		public int Id { get; set; }

		[ForeignKey("ShoppingCartId")]
		public int ShoppingCartId { get; set; }

		public ICollection<ShoppingCart> ShoppingCart { get; set; }

		public string? UserEmail { get; set; }

		public double FinalPrice { get; set; }

	}
}
