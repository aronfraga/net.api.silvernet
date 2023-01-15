using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Silvernet.Utils;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Silvernet.Models;

namespace Silvernet.Models.DTO {
	public class ShoppingCartUpdateDTO {

		[Key]
		public int Id { get; set; }

		[ForeignKey("ProductId")]
		[Required(ErrorMessage = Messages.SHOC_MOD_PROID)]
		public int ProductId { get; set; }

		[JsonIgnore]
		public Product Product { get; set; }

		[Required(ErrorMessage = Messages.SHOC_MOD_QTY)]
		public int Quantity { get; set; }

		[JsonIgnore]
		public double TotalPrice { get; set; }

		[ForeignKey("UserId")]
		[JsonIgnore]
		public int UserId { get; set; }

		[JsonIgnore]
		public User User { get; set; }

		[JsonIgnore]
		public bool Status { get; set; } = false;

	}
}

