using Silvernet.Models;

namespace Silvernet.Repository.IRepository {
	public interface IUserRepository {

		ICollection<User> GetAllUsers();

		User GetOneUser(int id);

		void ExistUser(string userName);

		Task<User> LoginAsync(User user);

		Task<User> RegisterAsync(User user);

	}
}
