using Microsoft.AspNetCore.Mvc;
using NueveYMedia.NumerologiaWebApplication.Modules;
using NueveYMedia.NumerologiaWebApplication.Services;

namespace NueveYMedia.NumerologiaWebApplication.Controllers
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
        private readonly INumerologyService numerologyService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, INumerologyService numerologyService)
        {
            _logger = logger;
            this.numerologyService = numerologyService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var X = this.numerologyService.GetNameSections("EDGAR BRIAN MAGANA ACOSTA");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("name")]
        public ActionResult GetName()
        {
            string fullName = "Elon Musk Reeve";
            List<NameSection> x = this.numerologyService.GetNameSections(fullName.ToUpper());
            var result = this.numerologyService.GetNumerologicalAnalysis(x);
            return Ok(result);
        }
    }
}