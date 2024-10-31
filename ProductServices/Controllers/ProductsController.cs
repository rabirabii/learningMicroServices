using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

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
        //[OutputCache]
        public async Task<IActionResult> Get()
        {
            await Task.Delay(5000);
            return Ok(Products);
        }
    }
}
