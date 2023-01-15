using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Silvernet.Mapper;
using Silvernet.Models;
using Silvernet.Models.DTO;
using Silvernet.Repository.IRepository;
using Silvernet.Utils;

namespace Silvernet.Controllers {

	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase {

		private readonly ICategoryRepository _repository;
		private readonly IMapper _mapper;

		public CategoriesController(ICategoryRepository repository, IMapper mapper) {
			_repository = repository;
			_mapper = mapper;
		}

		[Authorize]
		[HttpGet]
		public async Task<IActionResult> GetAllCategories() {
			try {
				var response = await _repository.GetAllCategories();
				return StatusCode(201, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

		[Authorize]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetOneCategory(int id) {
			try {
				var response = await _repository.GetOneCategory(id);
				return StatusCode(201, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> CreateCategory([FromBody] CategoryDTO categoryDTO) {
			try {
				if (!ModelState.IsValid) throw new Exception(Messages.MOD_INCORRECT);
				var responseDto = _mapper.Map<Category>(categoryDTO);
				var response = await _repository.CreateCategory(responseDto);
				return StatusCode(201, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

		[Authorize]
		[HttpPut]
		public async Task<IActionResult> UpdateCategory([FromBody] Category category) {
			try {
				if (!ModelState.IsValid) throw new Exception(Messages.MOD_INCORRECT);
				var response = await _repository.UpdateCategory(category);
				return StatusCode(201, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

		[Authorize]
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCategory(int id) {
			try {
				var response = await _repository.DeleteCategory(id);
				return StatusCode(200, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}
		
	}
}
