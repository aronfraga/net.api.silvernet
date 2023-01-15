using System.ComponentModel.DataAnnotations;

namespace Silvernet.Models.DTO {
	public class UserLoginResponseDTO {

		public User User { get; set; }

		public string Token { get; set; }

	}
}
