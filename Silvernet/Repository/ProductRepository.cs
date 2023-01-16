using Microsoft.EntityFrameworkCore;
using Silvernet.Data;
using Silvernet.Models;
using Silvernet.Models.DTO.ProductDTO;
using Silvernet.Repository.IRepository;
using Silvernet.Utils;

namespace Silvernet.Repository {
	public class ProductRepository : IProductRepository {

		private readonly Context _dbcontext;

		public ProductRepository(Context dbcontext) {
			_dbcontext = dbcontext;
		}

		public async Task<Product> CreateProduct(Product product) {

			if (product == null) throw new Exception(Messages.PRO_NOT_NULL);
			if (await ExistProduct(product.Model)) throw new Exception(Messages.PRO_EXIST);

			await _dbcontext.Products.AddAsync(product);
			await _dbcontext.SaveChangesAsync();

			return product;

		}

		public async Task<string> DeleteProduct(int id) {

			if (id == null || id == 0) throw new Exception(Messages.PRO_ID_NOT_NULL);
			var dbResponse = await GetOneProduct(id);
			if (dbResponse == null) throw new Exception(Messages.PRO_NOT_EXIST);

			_dbcontext.Products.Remove(dbResponse);
			await _dbcontext.SaveChangesAsync();

			return Messages.DELETED;

		}

		public async Task<bool> ExistProduct(string modelo) {
			bool value = await _dbcontext.Products.AnyAsync(data => data.Model.ToLower().Trim() == modelo.ToLower().Trim());
			return value;
		}

		public async Task<bool> ExistProduct(int id) {
			return await _dbcontext.Products.AnyAsync(data => data.Id == id);
		}

		public async Task<ICollection<Product>> GetAllProducts() {
			return await _dbcontext.Products.Include(data => data.Category).ToListAsync();
		}

		public async Task<Product> GetOneProduct(int id) {
			if (id == null || id == 0) throw new Exception(Messages.PRO_BY_PARAMS);
			var response =  await _dbcontext.Products.Include(data => data.Category).FirstOrDefaultAsync(data => data.Id == id);
			if (response == null) throw new Exception(Messages.PRO_NOT_EXIST);
			return response;
		}

		public async Task<Product> UpdateProduct(Product product) {
			
			if (product.Id == null || product.Id == 0) throw new Exception(Messages.PRO_ID_NOT_NULL);
			if (!await ExistProduct(product.Id)) throw new Exception(Messages.PRO_NOT_EXIST);

			_dbcontext.Products.Update(product);
			await _dbcontext.SaveChangesAsync();

			return product;

		}
	}
}
