using Microsoft.AspNetCore.Mvc;
using Syhael.Metadata;

namespace Syhael.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private readonly AppConfig _appConfig;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, AppConfig appConfig)
    {
        _logger = logger;
        _appConfig = appConfig;
    }

    [HttpGet]
    public AppConfig Get()
    {
        return this._appConfig;
    }
}
