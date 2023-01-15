using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Silvernet.Utils;

namespace Silvernet.Models.DTO {
	public class ProductDTO {

		[Key]
		[JsonIgnore]
		public int Id { get; set; }

		[Required(ErrorMessage = Messages.PRO_MOD_BRAND)]
		public string Brand { get; set; }

		[Required(ErrorMessage = Messages.PRO_MOD_MODEL)]
		public string Model { get; set; }

		public string Description { get; set; }

		[ForeignKey("CategoryId")]
		public int CategoryId { get; set; }

		[Required(ErrorMessage = Messages.PRO_MOD_PRICE)]
		public double Price { get; set; }

		[Required(ErrorMessage = Messages.PRO_MOD_STOCK)]
		public int Stock { get; set; }
	}
}