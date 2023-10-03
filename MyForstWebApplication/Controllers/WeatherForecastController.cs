using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyForstWebApplication.Models;

namespace MyForstWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {

        private WeatherForecastHolder _weatherForecastHolder;

        public WeatherForecastController(
            WeatherForecastHolder weatherForecastHolder)
        {
            _weatherForecastHolder = weatherForecastHolder;
        }

        [HttpPost("add")]
        public IActionResult Add([FromQuery]  DateTime date, [FromQuery] int temperatureC)
        {
            _weatherForecastHolder.Add(date, temperatureC); 
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] DateTime date, [FromQuery] int temperatureC)
        {
            bool updated = _weatherForecastHolder.Update(date, temperatureC);

            if (updated)
            {
                return Ok();
            }
            else
            {
                return NotFound(); // Возвращаем 404, если запись не найдена
            }
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] DateTime date)
        {
            bool deleted = _weatherForecastHolder.Delete(date);

            if (deleted)
            {
                return Ok();
            }
            else
            {
                return NotFound(); // Возвращаем 404, если запись не найдена
            }
        }

        [HttpGet("get")]
        public IActionResult Get([FromQuery] DateTime dateFrom, [FromQuery] DateTime dateTo)
        {
            List<WeatherForecast> list = _weatherForecastHolder.Get(dateFrom, dateTo);
            return Ok(list);
        }


    }
}
