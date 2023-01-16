using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Silvernet.Models.DTO {
	public class OrderDetailViewDTO {

		[Key]
		public int Id { get; set; }

		[ForeignKey("UserId")]
		[JsonIgnore]
		public int UserId { get; set; }

		public User User { get; set; }

		public ICollection<ShoppingCart> shoppingCart { get; set; }	

		public Double FinalPrice { get; set; }

	}
}
