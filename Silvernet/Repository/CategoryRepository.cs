using Microsoft.EntityFrameworkCore;
using Silvernet.Data;
using Silvernet.Models;
using Silvernet.Repository.IRepository;
using Silvernet.Utils;

namespace Silvernet.Repository {
	public class CategoryRepository : ICategoryRepository {

		private readonly Context _dbcontext;

		public CategoryRepository(Context dbcontext) {
			_dbcontext = dbcontext;
		}

		public async Task<Category> CreateCategory(Category category) {

			if (category == null) throw new Exception(Messages.CAT_NOT_NULL);
			if (await ExistCategory(category.Name)) throw new Exception(Messages.CAT_EXIST);
			
			_dbcontext.Categories.Add(category);
			await _dbcontext.SaveChangesAsync();

			return category;

		}

		public async Task<string> DeleteCategory(int id) {

			if (id == null || id == 0) throw new Exception(Messages.CAT_ID_NOT_NULL);
			var dbResponse = await GetOneCategory(id);
			if (dbResponse == null) throw new Exception(Messages.CAT_NOT_EXIST);
			
			_dbcontext.Categories.Remove(dbResponse);
			await _dbcontext.SaveChangesAsync();

			return Messages.DELETED;

		}

		public async Task<bool> ExistCategory(string name) {
			bool value = await _dbcontext.Categories.AnyAsync(data => data.Name.ToLower().Trim() == name.ToLower().Trim());
			return value;
		}

		public async Task<bool> ExistCategory(int id) {
			return await _dbcontext.Categories.AnyAsync(data => data.Id == id);
		}

		public async Task<ICollection<Category>> GetAllCategories() {
			return await _dbcontext.Categories.ToListAsync();
		}

		public async Task<Category> GetOneCategory(int id) {
			if (id == null || id == 0) throw new Exception(Messages.CAT_BY_PARAMS);
			return await _dbcontext.Categories.FirstOrDefaultAsync(data => data.Id == id);
		}

		public async Task<Category> UpdateCategory(Category category) {

			if (category.Id == null || category.Id == 0) throw new Exception(Messages.CAT_ID_NOT_NULL);
			if (!await ExistCategory(category.Id)) throw new Exception(Messages.CAT_NOT_EXIST);
			if (await ExistCategory(category.Name)) throw new Exception(Messages.CAT_SAME_NAME);

			_dbcontext.Categories.Update(category);
			await _dbcontext.SaveChangesAsync();

			return category;

		}
	}
}
