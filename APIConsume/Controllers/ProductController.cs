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

        [HttpPost("/[controller]")]
        public IActionResult Product([FromBody] Bukimedia.PrestaSharp.Entities.product product)
        {
            productFactory.Add(product);
            return Ok(product);
        }

        [HttpPost("/[controller]/UpdateOrInsertProduct/")]
        public IActionResult UpdateOrInsertProduct([FromBody] Bukimedia.PrestaSharp.Entities.product mikroProduct)
        {
            Boolean degisiklikVarMi = false;

            var filter = new Dictionary<string, string>
            {
                { "isbn", mikroProduct.isbn + "" }
            };

            // isbn'si ortusen productlar geliyor, unic oldugu icin 1 tane gelecek eger tabloda varsa
            var products = productFactory.GetByFilter(filter, null, null);

            Bukimedia.PrestaSharp.Entities.product prestaProduct = null;

            // getByFilter'dan dizi donuyor, eger bossa mikroProduct mikroya yeni eklenmis bir urundur
            if (products.Count != 0)
            {
                // dizi bos degil, isbn de unic oldugu icin ilk elemani aliyoruz
                prestaProduct = products[0];

                // urunun isminde degisiklik varsa guncelliyoruz
                if (prestaProduct.name[0].Value != mikroProduct.name[0].Value)
                {
                    prestaProduct.name[0].Value = mikroProduct.name[0].Value;
                    degisiklikVarMi = true;
                }
                // yine urunun fiyatinda degisiklik varsa guncelliyoruz
                if (prestaProduct.price != mikroProduct.price)
                {
                    prestaProduct.price = mikroProduct.price;
                    degisiklikVarMi = true;
                }

                if (degisiklikVarMi)
                {
                    productFactory.Update(prestaProduct);
                }
            }
            // eger buraya girerse bu urun mikroya yeni eklenmis bir urun, o halde prestashop'a ekliyoruz
            else
            {
                productFactory.Add(mikroProduct);
            }
                        
            return Ok(prestaProduct);
        }
    }
}
