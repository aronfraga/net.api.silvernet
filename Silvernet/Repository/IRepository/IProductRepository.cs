using Silvernet.Models;

namespace Silvernet.Repository.IRepository {
	public interface IProductRepository {

		Task<ICollection<Product>> GetAllProducts();

		Task<Product> GetOneProduct(int id);

		Task<bool> ExistProduct(string modelo);

		Task<bool> ExistProduct(int id);

		Task<string> CreateProduct(Product product);

		Task<string> UpdateProduct(Product product);

		Task<string> DeleteProduct(int id);

	}
}
