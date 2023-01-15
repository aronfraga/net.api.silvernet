using Silvernet.Models;

namespace Silvernet.Repository.IRepository {
	public interface IShoppingCartRepository {

		Task<ICollection<ShoppingCart>> GetAllShoppingCart();

		Task<ICollection<ShoppingCart>> GetAllShoppingCart(string status);

		Task<ShoppingCart> GetOneShoppingCart(int id);

		Task<ShoppingCart> GetOneShoppingCart(int id, bool status);

		Task<bool> ExistShoppingCart(int id);

		Task<string> CreateShoppingCart(ShoppingCart shoppingCart, string email);

		Task<string> UpdateShoppingCart(ShoppingCart shoppingCart);

		Task<string> DeleteShoppingCart(int id);

	}
}
