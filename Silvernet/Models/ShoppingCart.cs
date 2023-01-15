﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Silvernet.Utils;

namespace Silvernet.Models {
	public class ShoppingCart {

		[Key]
		public int Id { get; set; }

		[ForeignKey("ProductId")]
		[JsonIgnore]
		[Required(ErrorMessage = Messages.SHOC_MOD_PROID)]
		public int ProductId { get; set; }
		
		public Product Product { get; set; }

		[Required(ErrorMessage = Messages.SHOC_MOD_QTY)]
		public int Quantity { get; set; }

		public double TotalPrice { get; set; }

		public int? UserId { get; set; }
		
		public string? UserEmail { get; set; }

		public bool Status { get; set; } = false;

	}
}
