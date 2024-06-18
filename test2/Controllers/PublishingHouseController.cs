using Microsoft.AspNetCore.Mvc;
using test2.Services;

namespace test2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PublishingHouseController : ControllerBase
{
    private readonly IPublishingHouseService _publishingHouseService;

    public PublishingHouseController(IPublishingHouseService publishingHouseService)
    {
        _publishingHouseService = publishingHouseService;
    }

    [HttpGet]
    public IActionResult GetAll([FromQuery] string city, [FromQuery] string country)
    {
        var publishingHouses = _publishingHouseService.GetPublishingHouses(city, country);
        return Ok(publishingHouses);
    }
}