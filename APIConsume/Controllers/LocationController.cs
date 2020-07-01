using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIConsume.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIConsume.Controllers

{
    [Route("[controller]")]
    [ApiController]
    public class LocationController : Controller
    {
        // gen yazilim adresi
        Konum k1 = new Konum(41.0130647, 29.087207);

        // kadikoy evlendirme dairesi
        Konum k2 = new Konum(40.9908539, 29.0367496);

        [HttpGet("/[controller]")]
        public IActionResult Index()
        {
            double distance = k1.getDistance(k2);
            return Ok(distance);
        }
    }
}
