using Silvernet.Models.DTO.ProductDTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Silvernet.Models {
	public class OrderDetail {

		[Key]
		public int Id { get; set; }

		[ForeignKey("UserId")]
		[JsonIgnore]
		public int  UserId { get; set; }

		public User User { get; set; }

		public Double FinalPrice { get; set; }

	}
}
