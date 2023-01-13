using Silvernet.Models;

namespace Silvernet.Repository.IRepository {
	public interface ICategoryRepository {

		ICollection<Category> GetAllCategories();

		Category GetOneCategory(int id);

		bool ExistCategory(string name);

		bool ExistCategory(int id);

		string CreateCategory(Category category);

		string UpdateCategory(Category category);

		string DeleteCategory(int id);

	}
}
