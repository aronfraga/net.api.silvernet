using Silvernet.Models;

namespace Silvernet.Repository.IRepository {
	public interface IProductRepository {

		ICollection<Product> SearchProduct(string modelo);

		ICollection<Product> GetAllProducts();

		Product GetOneProduct(int id);

		bool ExistProduct(string modelo);

		bool ExistProduct(int id);

		string CreateProduct(Product product);

		string UpdateProduct(Product product);

		string DeleteProduct(int id);

	}
}
