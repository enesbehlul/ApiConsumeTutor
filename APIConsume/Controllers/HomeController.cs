using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using APIConsume.Models;
using Bukimedia.PrestaSharp.Factories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIConsume.Controllers
{
    public class HomeController : Controller
    {
        string BaseUrl = "http://localhost/prestashop/api";
        string Account = "RGRTYILCBUQATME8E352ZRRX7QVRLLDJ";
        string Password = "";

        private readonly AddressFactory _addressFactory;
        private readonly CustomerFactory _customerFactory;


        public HomeController()
        {
            _customerFactory = new CustomerFactory(BaseUrl, Account, Password);
            _addressFactory = new AddressFactory(BaseUrl, Account, Password);
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            //Bukimedia.PrestaSharp.Entities.manufacturer Manufacturer = _ManufacturerFactory.Get(6);
            //Manufacturer.name = "Iron Maiden";
            //Manufacturer.active = 1;
            //_ManufacturerFactory.Add(Manufacturer);
            

            return View(_addressFactory.GetAll());
        }

        public IActionResult GetAddressById(int id)
        {
            try
            {
                var address = _addressFactory.Get(id);
                return Ok(address);
            }
            catch (Exception)
            {
                return BadRequest();
            }            
        }

        public IActionResult GetAddressByCity([FromQuery]string city)
        {
            ////var address = _addressFactory.GetAll().FirstOrDefault(a => a.city.ToLower().StartsWith(city.ToLower()));
            var filter = new Dictionary<string, string>
            {
                { "city", city.ToLower() }
            };

            try
            {
                var address2 = _addressFactory.GetByFilter(filter, null, null);
                return Ok(address2);
            }
            catch (Exception)
            {
                return BadRequest();
            }            
        }

        // bu method sonradan gelistirilecek simdi erken
        bool adresMinumunGereksinimleriSagliyorMu(Bukimedia.PrestaSharp.Entities.address address)
        {
            if(address.id_customer == null || address.id_country == null)
            {

            }
            return false;
        }

        public IActionResult CreateAddress()
        {
         return View();
        }

        [HttpPost]
        public IActionResult CreateAddress([FromForm] Bukimedia.PrestaSharp.Entities.address address)
        {
            try
            {
                // minumum requirement saglanmiyorsa catch'e dusecek
                _addressFactory.Add(address);
            }
            catch (Exception exception)
            {
                return BadRequest();
            }
            
            return Ok();
        } 

        public IActionResult DeleteAddress(int id)
        {
            try
            {
                var address = _addressFactory.Get(id);
                _addressFactory.Delete(address);
                return Ok(address);
            }
            catch (Bukimedia.PrestaSharp.PrestaSharpException)
            {
                return BadRequest();
            }
        }

        public IActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromForm] Bukimedia.PrestaSharp.Entities.customer customer)
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

        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            try
            {
                var musteri = _customerFactory.Get(id);
                return View(musteri);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult UpdateCustomer([FromForm] Bukimedia.PrestaSharp.Entities.customer customer)
        {
            try
            {
                var musteri = _customerFactory.Get((long)customer.id);
                _customerFactory.Update(customer);
                return Ok(customer);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

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
                return BadRequest();
            }
        }

        // burada PrestaSharp kutuphanesini kullanmadan prestashop webservice'ini kullanmayi deneyecegim
        public async Task<IActionResult> Index3Async()
        {
            var url = "http://localhost/prestashop/api/addresses/1";
            var handler = new HttpClientHandler { Credentials = new NetworkCredential(Account, "") };
            var client = new HttpClient(handler);
            HttpResponseMessage response;
            response = await client.GetAsync(url);

            var a = await client.GetAsync(url);

            return Ok(a.Content.ReadAsStringAsync());
        }

    }
}
