using Silvernet.Data;
using Silvernet.Models;
using Silvernet.Repository.IRepository;

namespace Silvernet.Repository {
	public class CategoryRepository : ICateogoryRepository {

		private readonly Context _dbcontext;

		public CategoryRepository(Context dbcontext) {
			_dbcontext = dbcontext;
		}

		public string CreateCategory(Category category) {

			if (category == null) throw new Exception("The category cannot be empty or null");
			if (ExistCategory(category.Name)) throw new Exception("The Category is already in the database");
			
			_dbcontext.Categories.Add(category);
			_dbcontext.SaveChanges();

			return "Category created succesfully";
		}

		public string DeleteCategory(int id) {

			var dbResponse = GetOneCategory(id);
			if (!ExistCategory(dbResponse.Name)) throw new Exception("The category does not exist");
			
			_dbcontext.Categories.Remove(dbResponse);
			_dbcontext.SaveChanges();

			return "Category deleted succesfully";
		}

		public bool ExistCategory(string name) {
			return _dbcontext.Categories.Any(data => data.Name == name);
		}

		public bool ExistCategory(int id) {
			return _dbcontext.Categories.Any(data => data.Id == id);
		}

		public ICollection<Category> GetAllCategories() {
			return _dbcontext.Categories.ToList();
		}

		public Category GetOneCategory(int id) {
			return _dbcontext.Categories.FirstOrDefault(data => data.Id == id);
		}

		public string UpdateCategory(Category category) {

			if (category == null) throw new Exception("The category cannot be empty or null");
			var dbResponse = GetOneCategory(category.Id);
			if (!ExistCategory(dbResponse.Name)) throw new Exception("The category does not exist");

			_dbcontext.Categories.Add(category);
			_dbcontext.SaveChanges();

			return "Category updated succesfully";
		}
	}
}
