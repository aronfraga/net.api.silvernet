using Microsoft.EntityFrameworkCore;
using Silvernet.Data;
using Silvernet.Models;
using Silvernet.Repository.IRepository;
using System.IdentityModel.Tokens.Jwt;

namespace Silvernet.Repository {
	public class UserRepository : IUserRepository {

		private readonly Context _dbcontext;
		private string Secret;

		public UserRepository(Context dbcontext, IConfiguration config) {
			_dbcontext = dbcontext;
			Secret = config.GetValue<string>("ApiSettings:Secret");
		}

		public void ExistUser(string userName) {
			var dbResponse = _dbcontext.Users.FirstOrDefault(data => data.UserName == userName);
			if (dbResponse != null) throw new Exception("The User is already into database");
		}

		public User GetOneUser(int id) {
			var dbResponse = _dbcontext.Users.FirstOrDefault(data => data.Id == id);
			if (dbResponse == null) throw new Exception("The User does not exist");
			return dbResponse;
		}

		public ICollection<User> GetAllUsers() {
			return _dbcontext.Users.ToList();
		}

		public Task<User> LoginAsync(User user) {
			throw new NotImplementedException();
		}

		public Task<User> RegisterAsync(User user) {
			throw new NotImplementedException();
		}
	}
}
