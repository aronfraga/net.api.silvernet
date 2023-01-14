using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Silvernet.Models {
	public class ShoppingCart {

		[Key]
		public int Id { get; set; }

		[ForeignKey("ProductId")]
		public int ProductId { get; set; }

		public Product Product { get; set; }

		public int Quantity { get; set; }

		public int Price { get; set; }

		public int UserId { get; set; }

		[ForeignKey("UserId")]
		public User User { get; set; }

	}
}
