using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Interfaces;
using SharedModels;
using System.Text.Json;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private IOrdersService _ordersService;
        private readonly string _userServiceUrl = "https://localhost:7134/api/user";
        private readonly string _productServiceUrl = "https://localhost:7196/api/product";
        

        public OrderController(IHttpClientFactory httpClientFactory, IOrdersService ordersService)
        {
            _httpClientFactory = httpClientFactory;
            _ordersService = ordersService;
        }

        [HttpPost("Add Order")]
        public async Task<ActionResult<Order>> CreateOrder([FromBody] Order order)
        {
            var user = await GetUserById(order.UserId);
            if (user == null)
                return BadRequest("User not found");

            var product = await GetProductById(order.ProductId);
            if (product == null)
                return BadRequest("Product not found");


            _ordersService.Add(order);
            return Ok(order);
        }

        [HttpGet("Get All Orders")]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            try
            {
                var orders = _ordersService.GetOrders();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving orders: {ex.Message}");
            }
        }

        [HttpGet("Get Order/{id}")]
        public ActionResult<Order> GetOrder(int id)
        {
            try
            {
                var order = _ordersService.GetOrder(id);
                if (order == null)
                    return NotFound();

                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving order: {ex.Message}");
            }
        }

        [HttpPut("Update Order")]
        public IActionResult UpdateOrder(int id, Order newOrder)
        {
            try
            {
                _ordersService.Update(id, newOrder);
                return Ok("Order updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating order: {ex.Message}");
            }
        }

        [HttpDelete("Delete Order")]
        public IActionResult DeleteOrder(int id)
        {
            try
            {
                _ordersService.Delete(id);
                return Ok("Order deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting order: {ex.Message}");
            }
        }



        [HttpGet]
        private async Task<User?> GetUserById(int userId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_userServiceUrl}/{userId}");
            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<User>(json);

        }

        [HttpGet]
        public async Task<Product?> GetProductById(int productId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_productServiceUrl}/{productId}");
            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Product>(json);
        }

       

    }
}
