using Silvernet.Models;

namespace Silvernet.Repository.IRepository {
	public interface ICategoryRepository {

		Task<ICollection<Category>> GetAllCategories();

		Task<Category> GetOneCategory(int id);

		Task<bool> ExistCategory(string name);

		Task<bool> ExistCategory(int id);

		Task<Category> CreateCategory(Category category);

		Task<Category> UpdateCategory(Category category);

		Task<string> DeleteCategory(int id);

	}
}
