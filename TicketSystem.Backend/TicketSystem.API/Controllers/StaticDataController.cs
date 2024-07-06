using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TicketSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaticDataController : ControllerBase
    {
        [HttpGet("governorates")]
        public IActionResult GetGovernorates()
        {
            var governorates = new List<string>
            {
                "Governorate1",
                "Governorate2",
                "Governorate3"
            };
            return Ok(governorates);
        }

        [HttpGet("cities")]
        public IActionResult GetCities()
        {
            var cities = new List<string>
            {
                "City1",
                "City2",
                "City3"
            };
            return Ok(cities);
        }

        [HttpGet("districts")]
        public IActionResult GetDistricts()
        {
            var districts = new List<string>
            {
                "District1",
                "District2",
                "District3"
            };
            return Ok(districts);
        }
    }
}
