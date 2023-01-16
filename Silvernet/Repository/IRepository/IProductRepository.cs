using Silvernet.Models;
using Silvernet.Models.DTO.ProductDTO;

namespace Silvernet.Repository.IRepository {
	public interface IProductRepository {

		Task<ICollection<Product>> GetAllProducts();

		Task<Product> GetOneProduct(int id);

		Task<bool> ExistProduct(string modelo);

		Task<bool> ExistProduct(int id);

		Task<Product> CreateProduct(Product product);

		Task<Product> UpdateProduct(Product product);

		Task<string> DeleteProduct(int id);

	}
}
