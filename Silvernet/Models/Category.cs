﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Silvernet.Models {
	public class Category {

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "The name must be obligatory")]
		public string Name { get; set; }

	}
}
