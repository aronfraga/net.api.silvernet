﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Silvernet.Repository.IRepository;

namespace Silvernet.Controllers {

	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase {

		private readonly ICategoryRepository _repository;

		public CategoriesController(ICategoryRepository repository) {
			_repository = repository;
		}
		/*
		[HttpGet]
		public IActionResult GetAllCategories() {
			try {

			} catch (Exception ex) {

			}
		}

		[HttpGet]
		public IActionResult GetOneCategory() {
			try {

			} catch (Exception ex) {

			}
		}

		[HttpPost]
		public IActionResult CreateCategory() {
			try {

			} catch (Exception ex) {

			}
		}

		[HttpPut]
		public IActionResult UpdateCategory() {
			try {

			} catch (Exception ex) {

			}
		}

		[HttpDelete]
		public IActionResult DeleteCategory() {
			try {

			} catch (Exception ex) {

			}
		}
		*/
	}
}
