using AutoMapper;
using Silvernet.Models;
using Silvernet.Models.DTO;
using Silvernet.Models.DTO.ProductDTO;
using Silvernet.Models.DTO.ShoppingCartDTO;

namespace Silvernet.Mapper
{
    public class Mapper : Profile {

		public Mapper() {
			CreateMap<CategoryDTO, Category>().ReverseMap();
			CreateMap<ProductDTO, Product>().ReverseMap();
			CreateMap<ProductUpdateDTO, Product>().ReverseMap();
			CreateMap<ShoppingCartDTO, ShoppingCart>().ReverseMap();
		}

	}
}
