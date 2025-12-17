using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Db;

namespace WebAppliction.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public ILogger<WeatherForecastController> _logger;
        public WeatherDatabaseContext _weatherDatabaseContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherDatabaseContext weatherDatabaseContext)
        {
            _logger = logger;
            _weatherDatabaseContext = weatherDatabaseContext;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var query = _weatherDatabaseContext.WeatherForecasts.Select(x => new WeatherForecast
            {
                Date = x.Date,
                Summary = x.Summary,
                TemperatureC = x.TemperatureC
            });

            return query.ToList();
           
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}
