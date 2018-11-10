using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterCard.Api.Locations;
using Microsoft.AspNetCore.Mvc;
using TestMasterCard;

namespace vk.core.Controllers
{
    [Route("api/[controller]/")]
    public class ValuesController : Controller
    {

        //Координаты:
        //59.9397392 северной широты
        //30.3140793 восточной долготы
        // GET api/values
        //[HttpGet("{latitude}-{lontitude}")]
        public ATMLocations/*IEnumerable<double>*/ GetATMLocationsInfo(/*double latitude, double lontitude*/)
        {
            ATMLocations atmTest = MasterCard.Api.Locations.ATMLocationsTest.Get(1, -20);
            return atmTest/*$"latitude is {latitude} \n lontitude is {lontitude}"*/;
        }

        
        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
