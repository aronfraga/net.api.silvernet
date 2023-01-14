using Microsoft.EntityFrameworkCore;
using Silvernet.Data;
using Silvernet.Models;
using Silvernet.Repository.IRepository;
using Silvernet.Utils;

namespace Silvernet.Repository {
	public class ProductRepository : IProductRepository {

		private readonly Context _dbcontext;

		public ProductRepository(Context dbcontext) {
			_dbcontext = dbcontext;
		}

		public string CreateProduct(Product product) {

			if (product == null) throw new Exception(Messages.PRO_NOT_NULL);
			if (ExistProduct(product.Modelo)) throw new Exception(Messages.PRO_EXIST);

			_dbcontext.Products.Add(product);
			_dbcontext.SaveChanges();

			return Messages.CREATED;
		}

		public string DeleteProduct(int id) {

			if (id == null || id == 0) throw new Exception(Messages.PRO_ID_NOT_NULL);
			var dbResponse = GetOneProduct(id);
			if (dbResponse == null) throw new Exception(Messages.PRO_NOT_EXIST);

			_dbcontext.Products.Remove(dbResponse);
			_dbcontext.SaveChanges();

			return Messages.DELETED;
		}

		public bool ExistProduct(string modelo) {
			bool value = _dbcontext.Products.Any(data => data.Modelo.ToLower().Trim() == modelo.ToLower().Trim());
			return value;
		}

		public bool ExistProduct(int id) {
			return _dbcontext.Products.Any(data => data.Id == id);
		}

		public ICollection<Product> GetAllProducts() {
			return _dbcontext.Products.Include(data => data.Category).ToList();
		}

		public Product GetOneProduct(int id) {
			if (id == null || id == 0) throw new Exception(Messages.PRO_BY_PARAMS);
			return _dbcontext.Products.Include(data => data.Category).FirstOrDefault(data => data.Id == id);
		}

		public ICollection<Product> SearchProduct(string modelo) {
			
			IQueryable<Product> query = _dbcontext.Products;
			
			if (!string.IsNullOrEmpty(modelo)) 
				query = query.Where(data => data.Modelo.Contains(modelo));

			return query.ToList();
		}

		public string UpdateProduct(Product product) {
			if (product.Id == null || product.Id == 0) throw new Exception(Messages.PRO_ID_NOT_NULL);
			if (!ExistProduct(product.Id)) throw new Exception(Messages.PRO_NOT_EXIST);

			_dbcontext.Products.Update(product);
			_dbcontext.SaveChanges();

			return Messages.UPDATED;
		}
	}
}
