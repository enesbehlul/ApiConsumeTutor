using System;
using System.Collections.Generic;
using System.Linq;
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
                _addressFactory.Add(address);
            }
            catch (Exception exception)
            {
                return BadRequest();
            }
            
            return Ok();
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
            var musteri = _customerFactory.Get(id);
            if (musteri == null)
            {
                return BadRequest();
            }

            return View(musteri);
        }

        [HttpPost]
        public IActionResult UpdateCustomer([FromForm] Bukimedia.PrestaSharp.Entities.customer customer)
        {

            var musteri = _customerFactory.Get((long)customer.id);
            if (musteri == null)
            {
                return BadRequest();
            }

            _customerFactory.Update(customer);
            return Ok();
        }

        public IActionResult DeleteCustomer(long id)
        {
            var musteri = _customerFactory.Get(id);
            if (musteri == null)
            {
                return BadRequest();
            }

            _customerFactory.Delete(musteri);
            return Ok();
        }
    }
}
