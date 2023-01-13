using System.ComponentModel.DataAnnotations;

namespace Silvernet.Models {
	public class Category {

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "The name must be obligatory")]
		public string Name { get; set; }

	}
}
