using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bukimedia.PrestaSharp.Factories;
using Microsoft.AspNetCore.Mvc;

namespace APIConsume.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerFactory _customerFactory;

        string BaseUrl = "http://localhost/prestashop/api";
        string apiKey = "RGRTYILCBUQATME8E352ZRRX7QVRLLDJ";
        string Password = "";

        public CustomerController()
        {
            _customerFactory = new CustomerFactory(BaseUrl, apiKey, Password);
        }

        // GET: /<controller>/
        public async Task<IActionResult> Customers()
        {
            return Ok(_customerFactory.GetAll());
        }


        [HttpGet("/Home/Customers/{id}")]
        public IActionResult Customers(int id)
        {
            try
            {
                var customer = _customerFactory.Get(id);
                return Ok(customer);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        public IActionResult Customers([FromBody] Bukimedia.PrestaSharp.Entities.customer customer)
        {
            try
            {
                // minumum requirement saglanmiyorsa catch'e dusecek
                // daha once ayni id'ye sahip satir var mi diye bakmiyoruz cunku db zaten id'yi otomatik atiyor
                _customerFactory.Add(customer);
            }
            catch (Exception exception)
            {
                return BadRequest();
            }
            return Ok();
        }


        [HttpPut]
        public IActionResult UpdateCustomer([FromBody] Bukimedia.PrestaSharp.Entities.customer customer)
        {
            try
            {
                var musteri = _customerFactory.Get((long)customer.id);
                _customerFactory.Update(customer);
                return Ok(customer);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public IActionResult DeleteCustomer(long id)
        {
            try
            {
                var musteri = _customerFactory.Get(id);
                _customerFactory.Delete(musteri);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
