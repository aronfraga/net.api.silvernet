using Silvernet.Data;
using Silvernet.Models;
using Silvernet.Repository.IRepository;

namespace Silvernet.Repository {
	public class ProductCategory : IProductRepository {

		private readonly Context _dbcontext;

		public ProductCategory(Context dbcontext) {
			_dbcontext = dbcontext;
		}

		public string CreateProduct(Product product) {

			if (product == null) throw new Exception("The product cannot be empty or null");
			if (ExistProduct(product.Name)) throw new Exception("The product is already in the database");

			_dbcontext.Products.Add(product);
			_dbcontext.SaveChanges();

			return "Category created succesfully";
		}

		public string DeleteProduct(int id) {

			var dbResponse = GetOneProduct(id);
			if (!ExistProduct(dbResponse.Name)) throw new Exception("The product does not exist");

			_dbcontext.Products.Remove(dbResponse);
			_dbcontext.SaveChanges();

			return "The product was deleted";
		}

		public bool ExistProduct(string name) {
			bool value = _dbcontext.Products.Any(data => data.Name.ToLower().Trim() == name.ToLower().Trim());
			return value;
		}

		public bool ExistProduct(int id) {
			return _dbcontext.Products.Any(data => data.Id == id);
		}

		public ICollection<Product> GetAllProducts() {
			return _dbcontext.Products.ToList();
		}

		public Product GetOneProduct(int id) {
			return _dbcontext.Products.FirstOrDefault(data => data.Id == id);
		}

		public ICollection<Product> SearchProduct(string name) {
			
			IQueryable<Product> query = _dbcontext.Products;
			
			if (!string.IsNullOrEmpty(name)) 
				query = query.Where(data => data.Name.Contains(name));

			return query.ToList();
		}

		public string UpdateProduct(Product product) {

			if (product == null) throw new Exception("The product cannot be empty or null");
			var dbResponse = GetOneProduct(product.Id);
			if (!ExistProduct(dbResponse.Name)) throw new Exception("The product does not exist");

			_dbcontext.Products.Add(product);
			_dbcontext.SaveChanges();

			return "Category updated succesfully";
		}
	}
}
