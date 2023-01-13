using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silvernet.Models {
	public class Product {

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "The name must be obligatory")]
		public string Name { get; set; }

		public string Description { get; set; }

		[ForeignKey("CategoryId")]
		public int CategoryId { get; set; }

		public Category Category { get; set; }

		[Required(ErrorMessage = "The price must be obligatory")]
		public double Price { get; set; }

		[Required(ErrorMessage = "The Stock must be obligatory")]
		public int Stock { get; set; }

	}
}
