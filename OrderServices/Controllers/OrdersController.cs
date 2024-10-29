using Microsoft.AspNetCore.Mvc;
using OrderServices.Model;

namespace OrderServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        public Task<ActionResult<List<OrderModel>>> GetOrders()
        {
            try
            {
                var orders = new List<OrderModel>();
                orders.AddRange(new List<OrderModel>
                {
                    new OrderModel(1, "John", "Laptop"),
                    new OrderModel(2, "Bob", "Smartphone")
                });

                if (orders == null || !orders.Any())
                {
                    return Task.FromResult<ActionResult<List<OrderModel>>>(NotFound("Order not found!"));
                }

                return Task.FromResult<ActionResult<List<OrderModel>>>(Ok(orders));
            }
            catch (Exception ex)
            {
                return Task.FromResult<ActionResult<List<OrderModel>>>(StatusCode(500, $"Internal server Error : {ex.Message}"));
            }
        }
    }
}