using Silvernet.Utils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Silvernet.Models.DTO {
	public class CategoryDTO {

		[Key]
		[JsonIgnore]
		public int Id { get; set; }

		[Required(ErrorMessage = Messages.CAT_MOD_NAME)]
		public string Name { get; set; }

	}
}
