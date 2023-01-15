using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;
using Silvernet.Data;
using Silvernet.Models;
using Silvernet.Repository.IRepository;
using Silvernet.Utils;

namespace Silvernet.Repository {
	public class ShoppingCartRepository : IShoppingCartRepository {

		private readonly Context _dbcontext;

		public ShoppingCartRepository(Context dbcontext) {
			_dbcontext = dbcontext;
		}

		public async Task<string> CreateShoppingCart(ShoppingCart shoppingCart, string email) {

			if (shoppingCart.ProductId == 0 || shoppingCart.Quantity == 0) throw new Exception(Messages.SHOC_NOT_NULL);

			var product = await _dbcontext.Products.FirstOrDefaultAsync(data => data.Id == shoppingCart.ProductId);
			if (product == null) throw new Exception(Messages.PRO_NOT_EXIST);
			if (shoppingCart.Quantity > product.Stock) throw new Exception(Messages.SHOC_NOT_STOCK);

			var user = await _dbcontext.Users.FirstOrDefaultAsync(data => data.Email == email.ToLower().Trim());

			shoppingCart.UserId = user.Id;
			shoppingCart.TotalPrice = product.Price * shoppingCart.Quantity;
			shoppingCart.Status = false;

			await _dbcontext.ShoppingCarts.AddAsync(shoppingCart);
			await _dbcontext.SaveChangesAsync();

			return Messages.CREATED;

		}

		public async Task<string> DeleteShoppingCart(int id) {

			if (id == null || id == 0) throw new Exception(Messages.SHOC_ID_NOT_NULL);
			var dbResponse = await GetOneShoppingCart(id, false);
			if (dbResponse == null) throw new Exception(Messages.SHOC_NOT_EXIST_OR);

			_dbcontext.Remove(dbResponse);
			await _dbcontext.SaveChangesAsync();

			return Messages.DELETED;

		}

		public async Task<bool> ExistShoppingCart(int id) {
			return await _dbcontext.ShoppingCarts.AnyAsync(data => data.Id == id);
		}

		public async Task<ICollection<ShoppingCart>> GetAllShoppingCart() {
			return await _dbcontext.ShoppingCarts.Include(data => data.Product)
												 .Include(data => data.Product.Category)
												 .Include(data => data.User)
												 .ToListAsync();
		}

		public async Task<ICollection<ShoppingCart>> GetAllShoppingCart(string status) { 

			if(status.ToLower() != "finished" || status.ToLower() != "pending") throw new Exception("");
			var statusBool = status.ToLower() == "finished" ? true : false;
			
			return await _dbcontext.ShoppingCarts.Include(data => data.Product)
												 .Include(data => data.Product.Category)
												 .Include(data => data.User)
												 .Where(data => data.Status == statusBool)
												 .ToListAsync();

		}

		public async Task<ShoppingCart> GetOneShoppingCart(int id) {

			if (id == null || id == 0) throw new Exception(Messages.SHOC_ID_NOT_NULL);
			if (!await ExistShoppingCart(id)) throw new Exception(Messages.SHOC_NOT_EXIST);
			
			var response = await _dbcontext.ShoppingCarts.Include(data => data.Product)
														 .Include(data => data.Product.Category)
														 .Include(data => data.User)
														 .FirstOrDefaultAsync(data => data.Id == id);

			if (response == null) throw new Exception(Messages.SHOC_NOT_EXIST);
			return response;

		}

		public async Task<ShoppingCart> GetOneShoppingCart(int id, bool status) {

			if (id == null || id == 0) throw new Exception(Messages.SHOC_ID_NOT_NULL);
			if (!await ExistShoppingCart(id)) throw new Exception(Messages.SHOC_NOT_EXIST);

			var response = await _dbcontext.ShoppingCarts.Include(data => data.Product)
														 .Include(data => data.Product.Category)
														 .FirstOrDefaultAsync(data => data.Id == id && data.Status == status);

			if (response == null) throw new Exception(Messages.SHOC_NOT_EXIST);
			return response;

		}

		public async Task<string> UpdateShoppingCart(ShoppingCart shoppingCart) {

			if (shoppingCart.Id == 0) throw new Exception(Messages.SHOC_ID_NOT_NULL);
			if (!await ExistShoppingCart(shoppingCart.Id)) throw new Exception(Messages.SHOC_NOT_EXIST);
			if (shoppingCart.ProductId == 0 || shoppingCart.Quantity == 0) throw new Exception(Messages.SHOC_NOT_NULL);

			var product = await _dbcontext.Products.FirstOrDefaultAsync(data => data.Id == shoppingCart.ProductId);
			if (product == null) throw new Exception(Messages.PRO_NOT_EXIST);
			if (shoppingCart.Quantity > product.Stock) throw new Exception(Messages.SHOC_NOT_STOCK);

			shoppingCart.TotalPrice = product.Price * shoppingCart.Quantity;

			_dbcontext.ShoppingCarts.Update(shoppingCart);
			await _dbcontext.SaveChangesAsync();

			return Messages.UPDATED;

		}

	}
}
