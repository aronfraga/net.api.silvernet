using Silvernet.Models;
using Silvernet.Models.DTO.ShoppingCartDTO;

namespace Silvernet.Repository.IRepository {
	public interface IShoppingCartRepository {

		Task<ICollection<ShoppingCart>> GetAllShoppingCart();

		Task<ICollection<ShoppingCart>> GetAllShoppingCart(string userEmail);

		Task<ICollection<ShoppingCart>> GetAllShoppingCart(bool status);

		Task<ShoppingCart> GetOneShoppingCart(int id);

		Task<ShoppingCart> GetOneShoppingCart(int id, bool status);

		Task<bool> ExistShoppingCart(int id);

		Task<string> CreateShoppingCart(ShoppingCart shoppingCart, string email);

		Task<string> UpdateShoppingCart(ShoppingCartUpdateDTO shoppingCartUpdateDTO);

		Task<string> DeleteShoppingCart(int id);

	}
}
