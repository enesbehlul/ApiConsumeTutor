using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bukimedia.PrestaSharp.Factories;
using Microsoft.AspNetCore.Mvc;

namespace APIConsume.Controllers
{
    public class CartController : Controller
    {
        private readonly CartFactory _cartFactory;

        string BaseUrl = "http://localhost/prestashop/api";
        string apiKey = "RGRTYILCBUQATME8E352ZRRX7QVRLLDJ";
        string Password = "";

        public CartController()
        {
            _cartFactory = new CartFactory(BaseUrl, apiKey, Password);
        }

        // GET: /<controller>/
        [HttpGet("/Carts/")]
        public async Task<IActionResult> Carts()
        {
            return Ok(_cartFactory.GetAll());
        }

        [HttpGet("/Carts/{id}")]
        public IActionResult Carts(int id)
        {
            try
            {
                var cart = _cartFactory.Get(id);
                return Ok(cart);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("/Carts/")]
        public IActionResult Carts([FromBody] Bukimedia.PrestaSharp.Entities.cart cart)
        {
            try
            {
                // minumum requirement saglanmiyorsa catch'e dusecek
                // daha once ayni id'ye sahip satir var mi diye bakmiyoruz cunku db zaten id'yi otomatik atiyor
                _cartFactory.Add(cart);
            }
            catch (Exception exception)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCart([FromBody] Bukimedia.PrestaSharp.Entities.cart cart)
        {
            try
            {
                var tempCart = _cartFactory.Get((long)cart.id);
                //cart tanimliysa guncelleyecek degilse exceptiona dusecek
                _cartFactory.Update(cart);
                return Ok(cart);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public IActionResult DeleteCart(long id)
        {
            try
            {
                var cart = _cartFactory.Get(id);
                _cartFactory.Delete(cart);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
