using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MB.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("/MyCustomer")]
        public async Task<IActionResult> GetSomething(string getparam)
        {
            // do something
            return await Task.Run(() => StatusCode((int)HttpStatusCode.OK, $"this is getparam " + getparam));
        }

        [HttpPost]
        [Route("/MyCustomer")]
        public async Task<IActionResult> PostSomething(MyCustomer mycustomer)
        {
            // do something
            mycustomer.Status = ":Server Side Update";
            return await Task.Run(() => StatusCode((int)HttpStatusCode.OK, mycustomer));
        }

        [HttpDelete]
        [Route("/MyCustomer")]
        public async Task<IActionResult> PutSomething(MyCustomer mycustomer)
        {
            // do something
            mycustomer.Status = ":Server Side Deleted";
            return await Task.Run(() => StatusCode((int)HttpStatusCode.OK, mycustomer));
            
        }
    }

    public class MyCustomer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
    }
}
