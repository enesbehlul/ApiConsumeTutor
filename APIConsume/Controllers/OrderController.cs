using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bukimedia.PrestaSharp.Factories;
using Microsoft.AspNetCore.Mvc;

namespace APIConsume.Controllers
{

    public class OrderController : Controller
    {

        private readonly OrderFactory orderFactory;

        string BaseUrl = "http://localhost/prestashop/api";
        string apiKey = "RGRTYILCBUQATME8E352ZRRX7QVRLLDJ";
        string Password = "";


        public OrderController()
        {
            orderFactory = new OrderFactory(BaseUrl, apiKey, Password);
        }

        [HttpGet("/Orders")]
        public IActionResult Orders()
        {
            return Ok(orderFactory.GetAll());
        }

        [HttpGet("/Orders/{id}")]
        public IActionResult Orders(int id)
        {
            return Ok(orderFactory.Get(id));
        }

        [HttpPost("/Orders")]
        public IActionResult Orders([FromBody] Bukimedia.PrestaSharp.Entities.order order)
        {
            orderFactory.Add(order);

            return Ok(order);
        }
    }
}
