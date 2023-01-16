using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Silvernet.Models.DTO.ProductDTO;
using Silvernet.Models;
using Silvernet.Repository.IRepository;
using Silvernet.Utils;
using System.IdentityModel.Tokens.Jwt;

namespace Silvernet.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class OrderDetailsController : ControllerBase {

		private readonly IOrderDetailRepository _repository;
		private readonly IMapper _mapper;

		public OrderDetailsController(IOrderDetailRepository repository, IMapper mapper) {
			_repository = repository;
			_mapper = mapper;
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> CreateOrderDetails() {
			try {
				var response = await _repository.CreateOrderDetail("aronfraga@gmail.com");
				return StatusCode(201, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

		[Authorize]
		[HttpGet]
		public async Task<IActionResult> GetAllOrderDetails() {
			try {
				var response = await _repository.GetAllOrderDetail();
				return StatusCode(200, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

		[Authorize]
		[Route("UserRegistered")]
		[HttpGet]
		public async Task<IActionResult> GetAllOrderDetailByUsers() {
			try {
				string autho = Request.Headers["Authorization"];
				if (autho == null) throw new Exception(Messages.NO_TOKEN);
				var token = new JwtSecurityToken(jwtEncodedString: autho.Substring(7));
				string userEmail = token.Claims.First(data => data.Type == "email").Value;

				var response = await _repository.GetAllOrderDetailByUser(userEmail);
				return StatusCode(200, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

		[Authorize]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetOneOrderDetail(int id) {
			try {
				var response = await _repository.GetOneOrderDetail(id);
				return StatusCode(200, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

	}
}
