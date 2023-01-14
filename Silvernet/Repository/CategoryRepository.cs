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

		public string CreateCategory(Category category) {

			if (category == null) throw new Exception(Messages.CAT_NOT_NULL);
			if (ExistCategory(category.Name)) throw new Exception(Messages.CAT_EXIST);
			
			_dbcontext.Categories.Add(category);
			_dbcontext.SaveChanges();

			return Messages.CREATED;
		}

		public string DeleteCategory(int id) {
			if (id == null || id == 0) throw new Exception(Messages.CAT_ID_NOT_NULL);
			var dbResponse = GetOneCategory(id);
			if (dbResponse == null) throw new Exception(Messages.CAT_NOT_EXIST);
			
			_dbcontext.Categories.Remove(dbResponse);
			_dbcontext.SaveChanges();

			return Messages.DELETED;
		}

		public bool ExistCategory(string name) {
			bool value = _dbcontext.Categories.Any(data => data.Name.ToLower().Trim() == name.ToLower().Trim());
			return value;
		}

		public bool ExistCategory(int id) {
			return _dbcontext.Categories.Any(data => data.Id == id);
		}

		public ICollection<Category> GetAllCategories() {
			return _dbcontext.Categories.ToList();
		}

		public Category GetOneCategory(int id) {
			if (id == null || id == 0) throw new Exception(Messages.CAT_BY_PARAMS);
			return _dbcontext.Categories.FirstOrDefault(data => data.Id == id);
		}

		public string UpdateCategory(Category category) {
			if (category.Id == null || category.Id == 0) throw new Exception(Messages.CAT_EXIST);
			if (ExistCategory(category.Name)) throw new Exception(Messages.CAT_SAME_NAME);

			_dbcontext.Categories.Update(category);
			_dbcontext.SaveChanges();

			return Messages.UPDATED;
		}
	}
}
