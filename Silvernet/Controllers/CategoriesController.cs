﻿using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Silvernet.Mapper;
using Silvernet.Models;
using Silvernet.Models.DTO;
using Silvernet.Repository.IRepository;

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
		
		[HttpGet]
		public IActionResult GetAllCategories() {
			try {
				var response = _repository.GetAllCategories();
				return StatusCode(302, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

		[HttpGet("{id}")]
		public IActionResult GetOneCategory(int id) {
			try {
				var response = _repository.GetOneCategory(id);
				return StatusCode(302, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}
		
		[HttpPost]
		public IActionResult CreateCategory([FromBody] CategoryDTO categoryDTO) {
			try {
				if (!ModelState.IsValid) throw new Exception("The model is not correct");
				var responseDto = _mapper.Map<Category>(categoryDTO);
				var response = _repository.CreateCategory(responseDto);
				return StatusCode(201, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}
		
		[HttpPut]
		public IActionResult UpdateCategory([FromBody] Category category) {
			try {
				if (!ModelState.IsValid) throw new Exception("The model is not correct");
				var response = _repository.UpdateCategory(category);
				return StatusCode(201, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteCategory(int id) {
			try {
				var response = _repository.DeleteCategory(id);
				return StatusCode(200, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}
		
	}
}
