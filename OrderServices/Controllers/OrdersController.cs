using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using OrderServices.Model;

namespace OrderServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        //[OutputCache(Duration = 120)]
        public async Task<ActionResult<List<OrderModel>>> GetOrders()
        {
            try
            {
                await Task.Delay(5000);
                var orders = new List<OrderModel>();
                orders.AddRange(new List<OrderModel>
                {
                    new OrderModel(1, "John", "Laptop"),
                    new OrderModel(2, "Bob", "Smartphone")
                });

                if (orders == null || !orders.Any())
                {
                    return await Task.FromResult<ActionResult<List<OrderModel>>>(NotFound("Order not found!"));
                }

                return await Task.FromResult<ActionResult<List<OrderModel>>>(Ok(orders));
            }
            catch (Exception ex)
            {
                return await Task.FromResult<ActionResult<List<OrderModel>>>(StatusCode(500, $"Internal server Error : {ex.Message}"));
            }
        }
    }
}