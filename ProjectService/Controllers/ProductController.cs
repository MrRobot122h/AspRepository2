using Microsoft.AspNetCore.Mvc;
using ProductService.Interfaces;
using SharedModels;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("Get Product")]
        public ActionResult<Product> GetProduct(int id)
        {
            try
            {
                var product = _productService.GetProduct(id);
                if (product == null)
                    return NotFound();

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving product: {ex.Message}");
            }
        }

        [HttpPost("Add Product")]
        public ActionResult<Product> SetProduct(Product newProduct)
        {
            try
            {
                if (newProduct == null)
                    return BadRequest("newProduct cannot be null");

                _productService.Add(newProduct);
                return Ok(newProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding product: {ex.Message}");
            }
        }

        [HttpGet("Get All Products")]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            try
            {
                var products = _productService.GetProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving product: {ex.Message}");
            }
        }

        [HttpPut("Update Product")]
        public IActionResult UpdateUser(int id, Product newProduct)
        {
            try
            {
                _productService.Update(id, newProduct);
                return Ok("Product updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating product: {ex.Message}");
            }
        }

        [HttpDelete("Delete Product")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _productService.Delete(id);
                return Ok("Product deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting product: {ex.Message}");
            }
        }
    }
}
