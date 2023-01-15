using Silvernet.Utils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Silvernet.Models.DTO.UserDTO
{
    public class UserRegisterDTO
    {

        [JsonIgnore]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }
}
