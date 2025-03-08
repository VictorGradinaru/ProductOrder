using Microsoft.AspNetCore.Mvc;
using ProductOrdersProject.Interfaces;
using Shared.Models;

namespace ProductOrdersProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/order/all
        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var orders = await _orderService.GetAllAsync();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/order/all
        [HttpPost("all")]
        public async Task<IActionResult> Post([FromBody] List<OrderDto> newOrders)
        {
            if (newOrders == null || !newOrders.Any())
            {
                return BadRequest("Order list is empty");
            }

            try
            {
                await _orderService.AddRangeAsync(newOrders);
                return Ok(new { message = $"{newOrders.Count} orders created successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to create orders: {ex.Message}");
            }
        }
    }
}
