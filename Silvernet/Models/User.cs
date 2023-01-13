using System.ComponentModel.DataAnnotations;

namespace Silvernet.Models {
	public class User {

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "The username must be obligatory")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "The email must be obligatory")]
		public string Email { get; set; }

		[Required(ErrorMessage = "The password must be obligatory")]
		public string Password { get; set; }

	}
}
