using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Silvernet.Utils;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Silvernet.Models.DTO.ShoppingCartDTO
{
    public class ShoppingCartUpdateDTO
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("ProductId")]
        [Required(ErrorMessage = Messages.SHOC_MOD_PROID)]
        public int ProductId { get; set; }

        [Required(ErrorMessage = Messages.SHOC_MOD_QTY)]
        public int Quantity { get; set; }

        [JsonIgnore]
        public double TotalPrice { get; set; }

        [ForeignKey("UserId")]
        [JsonIgnore]
        public int UserId { get; set; }

        [JsonIgnore]
        public bool Status { get; set; } = false;

    }
}

