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
        

        public HomeController()
        {
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

        [HttpPost]
        public Bukimedia.PrestaSharp.Entities.address Post([FromBody] Bukimedia.PrestaSharp.Entities.address address)
        {
            var a = 10;
            var _address = new Bukimedia.PrestaSharp.Entities.address
            {
                id_country = address.id_country,
                alias = address.alias,
                lastname = address.lastname,
                firstname = address.firstname,
                address1 = address.address1,
                city = address.city
            };

            _addressFactory.Add(_address);
            return _address;
        } 

    }
}
