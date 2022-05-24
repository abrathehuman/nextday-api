using Microsoft.AspNetCore.Mvc;

namespace nextday_api.Controllers;

[ApiController]
[Route("[controller]")]
public class NextDayController : ControllerBase
{

    private readonly ILogger<NextDayController> _logger;

    public NextDayController(ILogger<NextDayController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "Get")]
    public string Get(string givenDay)
    {
        var currentDate = DateTime.UtcNow;
        var currentDateDay = (DayOfWeek)(currentDate.Date.DayOfWeek);
        givenDay = givenDay.ToLower();

        if (currentDate.Date.DayOfWeek.ToString().ToLower() == givenDay)
            return string.Empty;

        for (var i = 1; i <= 7; i++)
            if (currentDate.Date.AddDays(i).Date.DayOfWeek.ToString().ToLower() == givenDay)
                return currentDate.Date.AddDays(i + 1).ToLongDateString();

        return string.Empty;
    }
}
