using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Silvernet.Data;
using Silvernet.Models;
using Silvernet.Models.DTO.UserDTO;
using Silvernet.Repository.IRepository;
using Silvernet.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;
using XSystem.Security.Cryptography;

namespace Silvernet.Repository
{
    public class UserRepository : IUserRepository {

		private readonly Context _dbcontext;
		private string _secret;

		public UserRepository(Context dbcontext, IConfiguration config) {
			_dbcontext = dbcontext;
			_secret = config.GetValue<string>("ApiSettings:Secret");
		}

		public async Task<bool> ExistUser(string email, string username) {
			bool valueEmail = await _dbcontext.Users.AnyAsync(data => data.Email.ToLower().Trim() == email.ToLower().Trim());
			bool valueUserName = await _dbcontext.Users.AnyAsync(data => data.UserName.ToLower().Trim() == username.ToLower().Trim());

			return valueEmail || valueUserName;
		}

		public async Task<ICollection<User>> GetAllUsers() {
			return await _dbcontext.Users.ToListAsync();
		}

		public async Task<User> GetOneUser(int id) {
			if (id == null || id == 0) throw new Exception(Messages.USER_BY_PARAMS);
			return await _dbcontext.Users.FirstOrDefaultAsync(data => data.Id == id);
		}

		public async Task<UserLoginResponseDTO> LoginUser(UserLoginDTO userLoginDTO) {

			var PasswordEncrypted = EncryptMD5(userLoginDTO.Password);

			var userResponse = await _dbcontext.Users.FirstOrDefaultAsync(data => data.UserName.ToLower() ==
															                      userLoginDTO.UserName.ToLower() &&
																				  data.Password == PasswordEncrypted);

			if (userResponse == null) throw new Exception(Messages.USER_USRN_PASSW);

			var handlerToken = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_secret);

			var tokenDescriptor = new SecurityTokenDescriptor {
				Subject = new ClaimsIdentity(new Claim[] {
					new Claim(ClaimTypes.NameIdentifier, userResponse.UserName.ToString()),
					new Claim(ClaimTypes.Email, userResponse.Email.ToString()),
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = handlerToken.CreateToken(tokenDescriptor);

			UserLoginResponseDTO userLoginResponseDTO = new UserLoginResponseDTO() {
				Token = handlerToken.WriteToken(token),
				User = userResponse,
			};

			return userLoginResponseDTO;

		}

		public async Task<string> RegisterUser(UserRegisterDTO userRegisterDTO) {

			new System.Net.Mail.MailAddress(userRegisterDTO.Email);
			if (await ExistUser(userRegisterDTO.Email, userRegisterDTO.UserName)) throw new Exception(Messages.USER_EXIST);

			var PasswordEncrypted = EncryptMD5(userRegisterDTO.Password);

			User user = new User() {
				UserName = userRegisterDTO.UserName,
				Email = userRegisterDTO.Email,
				Password = PasswordEncrypted,
			};

			await _dbcontext.Users.AddAsync(user);
			await _dbcontext.SaveChangesAsync();
			
			return Messages.CREATED + " Welcome " + user.UserName;

		}

		public static string EncryptMD5(string value) {

			MD5CryptoServiceProvider X = new MD5CryptoServiceProvider();
			
			byte[] data = System.Text.Encoding.UTF8.GetBytes(value);
			data = X.ComputeHash(data);
			
			string response = "";

			for (int i = 0; i < data.Length; i++) {
				response += data[i].ToString("x2").ToLower();
			}

			return response;

		}

	}
}
