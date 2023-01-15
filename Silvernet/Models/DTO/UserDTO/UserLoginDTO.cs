using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Silvernet.Utils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Silvernet.Models.DTO.UserDTO
{
    public class UserLoginDTO
    {

        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        public string UserName { get; set; }

        [JsonIgnore]
        [ValidateNever]
        public string Email { get; set; }

        public string Password { get; set; }

    }
}
