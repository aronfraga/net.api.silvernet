﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Silvernet.Models.DTO;
using Silvernet.Models;
using Silvernet.Repository.IRepository;
using AutoMapper;
using Silvernet.Utils;

namespace Silvernet.Controllers {
	
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase {

		private readonly IProductRepository _repository;
		private readonly IMapper _mapper;

		public ProductsController(IProductRepository repository, IMapper mapper) {
			_repository = repository;
			_mapper = mapper;
		}
		
		[HttpGet]
		public async Task<IActionResult> GetAllProducts() {
			try {
				var response = await _repository.GetAllProducts();
				return StatusCode(302, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetOneProduct(int id) {
			try {
				var response = await _repository.GetOneProduct(id);
				return StatusCode(302, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateProduct([FromBody] ProductDTO productDTO) {
			try {
				if (!ModelState.IsValid) throw new Exception(Messages.MOD_INCORRECT);
				var responseDto = _mapper.Map<Product>(productDTO);
				var response = await _repository.CreateProduct(responseDto);
				return StatusCode(201, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}
		
		[HttpPut]
		public async Task<IActionResult> UpdateProduct([FromBody] ProductUpdateDTO productUpdateDTO) {
			try {
				if (!ModelState.IsValid) throw new Exception(Messages.MOD_INCORRECT);
				var responseDto = _mapper.Map<Product>(productUpdateDTO);
				var response = await _repository.UpdateProduct(responseDto);
				return StatusCode(201, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProduct(int id) {
			try {
				var response = await _repository.DeleteProduct(id);
				return StatusCode(200, new { request_status = "successful", response = response });
			} catch (Exception ex) {
				return StatusCode(400, new { request_status = "unsuccessful", response = ex.Message });
			}
		}
		
	}
}
