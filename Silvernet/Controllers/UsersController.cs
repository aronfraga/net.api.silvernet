using AutoMapper;
using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Silvernet.Models;
using Silvernet.Models.DTO;
using Silvernet.Repository.IRepository;
using Silvernet.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using XAct.Messages;
using XAct.Users;

namespace Silvernet.Controllers {
	
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase {

		private readonly IUserRepository _repository;
		private readonly IMapper _mapper;

		public UsersController(IUserRepository repository, IMapper mapper) {
			_repository = repository;
			_mapper = mapper;
		}

		[HttpPost("register")]
		public async Task<IActionResult> RegisterUser([FromBody] UserRegisterDTO userRegisterDTO) {
			try {
				var response = await _repository.RegisterUser(userRegisterDTO);
				return StatusCode(201, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

		[HttpPost("login")]
		public async Task<IActionResult> LoginUser([FromBody] UserLoginDTO userLoginDTO) {
			try {
				var response = await _repository.LoginUser(userLoginDTO);
				return StatusCode(201, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

	}
}
