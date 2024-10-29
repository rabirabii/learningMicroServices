using Microsoft.AspNetCore.Mvc;

namespace ProductServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly string[] Products = new[]
        {
          "Clothes", "Bags", "Televisions", "Shoes", "Phones", "Accessories"
        };



        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Products);
        }
    }
}
