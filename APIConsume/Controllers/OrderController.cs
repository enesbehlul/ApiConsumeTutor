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
    public class OrderController : Controller
    {

        private readonly OrderFactory orderFactory;
        private readonly CartFactory cartFactory;
        private readonly ProductFactory productFactory;

        string BaseUrl = "http://localhost/prestashop/api";
        string apiKey = "RGRTYILCBUQATME8E352ZRRX7QVRLLDJ";
        string Password = "";


        public OrderController()
        {
            orderFactory = new OrderFactory(BaseUrl, apiKey, Password);
            cartFactory = new CartFactory(BaseUrl, apiKey, Password);
            productFactory = new ProductFactory(BaseUrl, apiKey, Password);
        }

        [HttpGet("/[controller]")]
        public IActionResult Orders()
        {
            return Ok(orderFactory.GetAll());
        }

        [HttpGet("/[controller]/{id}")]
        public IActionResult Orders(int id)
        {
            return Ok(orderFactory.Get(id));
        }

        [HttpPost("/[controller]")]
        public IActionResult Orders([FromBody] Bukimedia.PrestaSharp.Entities.order order)
        {
            // order olustururken her bir product icin orderDetail olusturmak gerekiyor
            // fakat orderdetail ayni zamanda order_id tutuyor, daha order olusturmadan orderdetail'e nasil
            // order id'si verebiliriz ki?

            //int cartId = (int) order.id_cart;
            //Bukimedia.PrestaSharp.Entities.cart cart = cartFactory.Get(cartId);


            //foreach (Bukimedia.PrestaSharp.Entities.cart_row cart_row in cart.associations.cart_rows)
            //{
            //    // sepetteki urunun idsi ile product cekiyoruz 
            //    Bukimedia.PrestaSharp.Entities.product prd = productFactory.Get((int) cart_row.id_product);


            //    Bukimedia.PrestaSharp.Entities.order_detail od = new Bukimedia.PrestaSharp.Entities.order_detail();

            //    od.product_name = prd.name[0].Value;
                
            //}


                orderFactory.Add(order);

            return Ok(order);
        }
    }
}
