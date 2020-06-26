using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using APIConsume.Models;
using Bukimedia.PrestaSharp.Factories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIConsume.Controllers
{
    public class AddressController : Controller
    {
        string BaseUrl = "http://localhost/prestashop/api";
        string apiKey = "RGRTYILCBUQATME8E352ZRRX7QVRLLDJ";
        string Password = "";

        private readonly AddressFactory _addressFactory;
        
        




        public AddressController()
        {
            _addressFactory = new AddressFactory(BaseUrl, apiKey, Password);
        }

        public async Task<IActionResult> Index()
        {
            


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Addresses()
        {
            //Bukimedia.PrestaSharp.Entities.manufacturer Manufacturer = _ManufacturerFactory.Get(6);
            //Manufacturer.name = "Iron Maiden";
            //Manufacturer.active = 1;
            //_ManufacturerFactory.Add(Manufacturer);
            

            return View(_addressFactory.GetAll());
        }

        [HttpGet("/Address/Addresses/{id}")]
        public IActionResult Addresses(int id)
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

        //[HttpGet("/Home/Addresses/{city}")]
        //public IActionResult Addresses(string city)
        //{
        //    ////var address = _addressFactory.GetAll().FirstOrDefault(a => a.city.ToLower().StartsWith(city.ToLower()));
        //    var filter = new Dictionary<string, string>
        //    {
        //        { "city", city.ToLower() }
        //    };

        //    try
        //    {
        //        var address2 = _addressFactory.GetByFilter(filter, null, null);
        //        return Ok(address2);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}

        [HttpPost]
        public IActionResult Addresses([FromBody] Bukimedia.PrestaSharp.Entities.address address)
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

        [HttpPut]
        public IActionResult UpdateAddress([FromBody] Bukimedia.PrestaSharp.Entities.address address)
        {
            try
            {
                var adres = _addressFactory.Get((long)address.id);
                _addressFactory.Update(address);
                return Ok(address);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete]
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
                return NotFound();
            }
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
