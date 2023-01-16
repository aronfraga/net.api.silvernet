using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;
using Silvernet.Data;
using Silvernet.Models;
using Silvernet.Models.DTO.ShoppingCartDTO;
using Silvernet.Models.DTO.UserDTO;
using Silvernet.Repository.IRepository;
using Silvernet.Utils;
using XAct.Users;

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

			product.Stock -= shoppingCart.Quantity;

			shoppingCart.UserId = user.Id;
			shoppingCart.TotalPrice = product.Price * shoppingCart.Quantity;
			shoppingCart.Status = false;

			_dbcontext.Products.Update(product);
			await _dbcontext.ShoppingCarts.AddAsync(shoppingCart);
			await _dbcontext.SaveChangesAsync();

			return Messages.CREATED;

		}

		public async Task<string> DeleteShoppingCart(int id) {

			if (id == null || id == 0) throw new Exception(Messages.SHOC_ID_NOT_NULL);
			var dbResponse = await GetOneShoppingCart(id, false);
			if (dbResponse == null) throw new Exception(Messages.SHOC_NOT_EXIST_OR);

			var product = await _dbcontext.Products.FirstOrDefaultAsync(data => data.Id == dbResponse.ProductId);

			product.Stock += dbResponse.Quantity;

			_dbcontext.Products.Update(product);
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

		public async Task<ICollection<ShoppingCart>> GetAllShoppingCart(bool status) {
			return await _dbcontext.ShoppingCarts.Include(data => data.Product)
												 .Include(data => data.Product.Category)
												 .Include(data => data.User)
												 .Where(data => data.Status == status)
												 .ToListAsync();
		}

		public async Task<ICollection<ShoppingCart>> GetAllShoppingCart(string userEmail) {

			var user = await _dbcontext.Users.FirstOrDefaultAsync(data => data.Email.ToLower() == userEmail.ToLower());
																	
			return await _dbcontext.ShoppingCarts.Include(data => data.Product)
												 .Include(data => data.Product.Category)
												 .Include(data => data.User)
												 .Where(data => data.UserId == user.Id)
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

		public async Task<string> UpdateShoppingCart(ShoppingCartUpdateDTO shoppingCartUpdateDTO) {

			if (shoppingCartUpdateDTO.ProductId == 0 || shoppingCartUpdateDTO.Quantity == 0) throw new Exception(Messages.SHOC_NOT_NULL);
			
			var oldShoppingCart = await GetOneShoppingCart(shoppingCartUpdateDTO.Id, false);
			if (oldShoppingCart == null) throw new Exception(Messages.SHOC_NOT_EXIST_OR);

			var product = await _dbcontext.Products.FirstOrDefaultAsync(data => data.Id == shoppingCartUpdateDTO.ProductId);
			if (product == null) throw new Exception(Messages.PRO_NOT_EXIST);
			
			if (shoppingCartUpdateDTO.Quantity > (product.Stock + oldShoppingCart.Quantity)) throw new Exception(Messages.SHOC_NOT_STOCK);

			product.Stock = (product.Stock + oldShoppingCart.Quantity) - shoppingCartUpdateDTO.Quantity;

			oldShoppingCart.Quantity = shoppingCartUpdateDTO.Quantity;
			oldShoppingCart.TotalPrice = product.Price * shoppingCartUpdateDTO.Quantity;
			oldShoppingCart.Status = false;

			_dbcontext.ShoppingCarts.Update(oldShoppingCart);
			await _dbcontext.SaveChangesAsync();

			return Messages.UPDATED;

		}

	}
}
