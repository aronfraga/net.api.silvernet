using Silvernet.Models;
using Silvernet.Models.DTO;

namespace Silvernet.Repository.IRepository {
	public interface IUserRepository {

		Task<ICollection<User>> GetAllUsers();

		Task<User> GetOneUser(int id);

		Task<bool> ExistUser(string email, string username);

		Task<UserLoginResponseDTO> LoginUser(UserLoginDTO userLoginDTO);

		Task<string> RegisterUser(UserRegisterDTO userRegisterDTO);

	}
}
