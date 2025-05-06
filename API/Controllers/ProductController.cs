using API.DTOs;
using API.DTOs.ProductDTO;
using API.Models;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            this._productService = productService;

        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var response = await _productService.GetAllProducts();
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var response = await _productService.GetProductById(id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost("Add")]
        public async Task<ActionResult> AddProduct(ProductAddDto todoAddDto)
        {
            var response = await _productService.AddProduct(todoAddDto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProduct(ProductUpdateDto ProductDto)
        {
            var response = await _productService.UpdateProduct(ProductDto);

            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response = await _productService.DeleteProduct(id);

            return StatusCode(response.StatusCode, response);
        }


    }
}
