using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Silvernet.Models;
using Silvernet.Repository.IRepository;
using Silvernet.Utils;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Silvernet.Models.DTO.ShoppingCartDTO;

namespace Silvernet.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class ShoppingCartController : ControllerBase {

		private readonly IShoppingCartRepository _repository;
		private readonly IMapper _mapper;

		public ShoppingCartController(IShoppingCartRepository repository, IMapper mapper) {
			_repository = repository;
			_mapper = mapper;
		}

		[Authorize]
		[HttpGet]
		public async Task<IActionResult> GetAllShoppingCart() {
			try {
				var response = await _repository.GetAllShoppingCart();
				return StatusCode(200, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

		[Authorize]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetOneShoppingCart(int id) {
			try {
				var response = await _repository.GetOneShoppingCart(id);
				return StatusCode(200, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

		[Authorize]
		[Route("UserRegistered")]
		[HttpGet]
		public async Task<IActionResult> GetAllByUser() {
			try {
				string autho = Request.Headers["Authorization"];
				if (autho == null) throw new Exception(Messages.NO_TOKEN);
				var token = new JwtSecurityToken(jwtEncodedString: autho.Substring(7));
				string userEmail = token.Claims.First(data => data.Type == "email").Value;

				var response = await _repository.GetAllShoppingCart(userEmail);
				return StatusCode(200, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> CreateShoppingCart([FromBody] ShoppingCartDTO shoppingCartDTO) {
			try {
				if (!ModelState.IsValid) throw new Exception(Messages.MOD_INCORRECT);

				string autho = Request.Headers["Authorization"];
				if (autho == null) throw new Exception(Messages.NO_TOKEN);
				var token = new JwtSecurityToken(jwtEncodedString: autho.Substring(7));
				string userEmail = token.Claims.First(data => data.Type == "email").Value;

				var responseDTO = _mapper.Map<ShoppingCart>(shoppingCartDTO);
				var response = await _repository.CreateShoppingCart(responseDTO, userEmail);

				return StatusCode(201, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

		[Authorize]
		[HttpPut]
		public async Task<IActionResult> UpdateShoppingCart([FromBody] ShoppingCartUpdateDTO shoppingCartUpdateDTO) {
			try {
				if (!ModelState.IsValid) throw new Exception(Messages.MOD_INCORRECT);
				var response = await _repository.UpdateShoppingCart(shoppingCartUpdateDTO);
				return StatusCode(201, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

		[Authorize]
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteShoppingCart(int id) {
			try {
				var response = await _repository.DeleteShoppingCart(id);
				return StatusCode(200, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

	}
}
