using System.ComponentModel.DataAnnotations;

namespace Silvernet.Models {
	public class User {

		[Key]
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

	}
}
