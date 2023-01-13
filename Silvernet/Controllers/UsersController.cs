using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Silvernet.Models;
using Silvernet.Repository.IRepository;

namespace Silvernet.Controllers {
	
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase {

		private readonly IUserRepository _repository;

		public UsersController(IUserRepository repository) {
			_repository = repository;
		}
		/*

		[HttpGet]
		public IActionResult GetAllUsers() {
			try {

			} catch (Exception ex) {

			}
		}

		[HttpGet]
		public IActionResult GetOneUser(int id) {
			try {

			} catch (Exception ex) {
	
			}
		}

		[HttpPut]
		public IActionResult UpdateUser([FromBody] User user) {
			try {

			} catch (Exception ex) {

			}
		}

		[HttpDelete]
		public IActionResult HardDeleteUser(int id) {
			try {

			} catch (Exception ex) {

			}
		}

		[HttpPost("register")]
		public async Task<IActionResult> RegisterUser([FromBody] User user) {
			try {

			} catch (Exception ex) {

			}
		}

		[HttpPost("login")]
		public async Task<IActionResult> LoginUser([FromBody] User user) {
			try {

			} catch (Exception ex) {

			}
		}

		*/

	}
}
