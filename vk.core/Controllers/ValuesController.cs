using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterCard.Api.Locations;
using Microsoft.AspNetCore.Mvc;
using TestMasterCard;
using Newtonsoft.Json;

namespace vk.core.Controllers
{
    [Route("api/[controller]/")]
    public class ValuesController : Controller
    {

        //Координаты:
        //59.9397392 северной широты
        //30.3140793 восточной долготы
        //GET api/values
        [HttpGet("{latitude}-{lontitude}")]
        public string GetATMLocationsInfo(double latitude, double lontitude)
        {
            var atmTest = new ATMLocations{};
            try {
                atmTest = MasterCard.Api.Locations.ATMLocationsTest.Get(latitude, lontitude);
            } catch (Exception ex) {
            }
            return JsonConvert.SerializeObject(atmTest); 
        }

    }
}
