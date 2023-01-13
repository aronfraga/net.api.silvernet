using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Silvernet.Repository.IRepository;

namespace Silvernet.Controllers {
	
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase {

		private readonly IProductRepository _repository;

		public ProductsController(IProductRepository repository) {
			_repository = repository;
		}
		/*
		[HttpGet]
		public IActionResult GetAllProducts() {
			try {

			} catch (Exception ex) {

			}
		}

		[HttpGet]
		public IActionResult GetOneProduct() {
			try {

			} catch (Exception ex) {

			}
		}

		[HttpPost]
		public IActionResult CreateProduct() {
			try {

			} catch (Exception ex) {

			}
		}

		[HttpPut]
		public IActionResult UpdateProduct() {
			try {

			} catch (Exception ex) {

			}
		}

		[HttpDelete]
		public IActionResult DeleteProduct() {
			try {

			} catch (Exception ex) {

			}
		}
		*/
	}
}
