using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using APIConsume.Models;
using Bukimedia.PrestaSharp.Factories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIConsume.Controllers
{
    public class HomeController : Controller
    {
        string BaseUrl = "http://localhost/prestashop/api";
        string apiKey = "RGRTYILCBUQATME8E352ZRRX7QVRLLDJ";
        string Password = "";

        private readonly AddressFactory _addressFactory;
        private readonly CustomerFactory _customerFactory;
        private readonly CartFactory _cartFactory;


        public HomeController()
        {
            _customerFactory = new CustomerFactory(BaseUrl, apiKey, Password);
            _addressFactory = new AddressFactory(BaseUrl, apiKey, Password);
            _cartFactory = new CartFactory(BaseUrl, apiKey, Password);
        }

        // GET: /<controller>/
        public async Task<IActionResult> Addresses()
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

        // GET: /<controller>/
        public async Task<IActionResult> Customers()
        {
            return View(_customerFactory.GetAll());
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

        // GET: /<controller>/
        public async Task<IActionResult> Carts()
        {
            return View(_cartFactory.GetAll());
        }


        // burada PrestaSharp kutuphanesini kullanmadan prestashop webservice'ini kullanmayi deneyecegim
        // bu satirdan itibaren bu sekilde
        public Task<IActionResult> Index3Async()
        {
            var url = "http://localhost/prestashop/api/addresses/2";


            return Execute(url, "GET", null);

            //return Ok(xmlData);
        }

        private async Task<IActionResult> Execute(string url, string method, XDocument document = null)
        {
            string header = String.Empty;
            string data = String.Empty;

            //string mediaType = (IOFormat.JSON == this.IO_FORMAT) ? "text/json" : "text/xml";
            string mediaType = "text/xml";

            using (var handler = new HttpClientHandler { Credentials = new NetworkCredential(this.apiKey, "") })
            using (var client = new HttpClient(handler))
            {
                HttpResponseMessage response;
                HttpContent content;

                try
                {
                    switch (method.ToUpper())
                    {
                        case "GET":
                            response = await client.GetAsync(url);
                            break;
                        case "POST":
                            response = await client.PostAsync(url, new StringContent(document.ToString(), Encoding.UTF8, mediaType));
                            break;
                        case "PUT":
                            response = await client.PutAsync(url, new StringContent(document.ToString(), Encoding.UTF8, mediaType));
                            break;
                        case "DELETE":
                            response = await client.DeleteAsync(url);
                            break;
                        case "HEAD":
                            response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));
                            break;
                        default:
                            throw new Exception("Invalid Http Method provided. GET, POST, PUT, DELETE, HEAD are valid");
                            break;
                    }
                }
                catch (HttpRequestException)
                {
                    throw new Exception("An error occured while sending the request");
                }

                header = response.Headers.ToString() + "\n";

                if (response != null)
                {
                    content = response.Content;
                    data = await content.ReadAsStringAsync();
                }

                response.Dispose();
            }

            return Ok(data);
        }

    }
}
