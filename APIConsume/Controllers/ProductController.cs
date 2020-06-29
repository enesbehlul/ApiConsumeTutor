using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bukimedia.PrestaSharp.Factories;
using Microsoft.AspNetCore.Mvc;

namespace APIConsume.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ProductFactory productFactory;

        string BaseUrl = "http://localhost/prestashop/api";
        string apiKey = "RGRTYILCBUQATME8E352ZRRX7QVRLLDJ";
        string Password = "";

        public ProductController()
        {
            productFactory = new ProductFactory(BaseUrl, apiKey, Password);
        }

        [HttpGet("/[controller]")]
        public IActionResult Product()
        {
            return Ok(productFactory.GetAll());
        }

        [HttpGet("/[controller]/{id}")]
        public IActionResult Product(int id)
        {
            return Ok(productFactory.Get(id));
        }
    }
}
